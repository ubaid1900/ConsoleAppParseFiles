using System.Data;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

internal class Program
{
    private static void Main(string[] args)
    {
        IEnumerable<string> filePaths = Directory.EnumerateFiles("C:\\Users\\DELL\\source\\repos\\ConsoleApp2\\ConsoleAppParseFiles\\extracted_text");
        //var unplattedPropertyRegexString = @"Unplatted Property(?<acres>.*)acres of land";
        string unplattedPropertyRegexString = @"Unplatted Property(?<acres>.*)acres of land";
        //string abstractNoAndCountyRegexString = @"Abstract No(?<absno>.*?)in(?<county>.*?)county";
        string abstractNoAndCountyRegexString = @"Abstract No(?<absno>.*?)in(?<county>.*?)(county|counties)";

        string geographicIdRegexString = @"GEOGRAPHIC ID:(?<geoid>(.|\n)*)?PROPERTY ID";
        string propertyIdRegexString = @"PROPERTY ID:(?<propid>(.|\n)*)?GEOGRAPHIC ID";

        string alternateGeographicIdRegexString = @"GEOGRAPHIC ID:(?<geoid>(.|\n)*)?For blanket easements";
        string alternatePropertyIdRegexString = @"PROPERTY ID:(?<propid>(.|\n)*)?For blanket easements";
        //PROPERTY ID:(?< propid >.*?)([.|\r\n |\r |\n |\s] *)
        //var unplattedPropertyRegex = new Regex(unplattedPropertyRegexString);

        // UTODO: taking only a few files
        //filePaths = filePaths.Take(15);//.Where(fp => fp.Contains("12999") || fp.Contains("13135") || fp.Contains("Thunder Punch"));
        //filePaths = filePaths.Where(fp => fp.Contains("28362"));

        DataTable dt = new DataTable();
        dt.Columns.Add("filename");
        dt.Columns.Add("unplatted_property");
        dt.Columns.Add("abstract_no");
        dt.Columns.Add("county");
        dt.Columns.Add("propertyid");
        dt.Columns.Add("geographicid");

        /*
         Unplatted Property:

        filename
        abstract_no
        county
        propertyid
        geographicid 
         */

        foreach (var filePath in filePaths)
        {
            if (filePath.Contains(".csv"))
            {
                continue;
            }
            //TextReader reader = new StreamReader(filePath);
            string data = File.ReadAllText(filePath);
            string filename = ExtractFileName(filePath);
            string unplatted_property = string.Empty;
            string abstract_no = string.Empty;
            string county = string.Empty;
            string propertyid = string.Empty;
            string geographicid = string.Empty;

            MatchCollection matches = Regex.Matches(data, unplattedPropertyRegexString, RegexOptions.IgnoreCase);
            if (matches.Any())
            {
                unplatted_property = matches.First().Groups["acres"].Value.TrimEnd().TrimStart().Trim('.').TrimEnd().TrimStart().Trim('.');
            }
            //else
            //{
            //    unplatted_property = "Unplatted Property NOT FOUND";
            //}
            matches = Regex.Matches(data, abstractNoAndCountyRegexString, RegexOptions.IgnoreCase);
            if (matches.Any())
            {
                abstract_no = matches.First().Groups["absno"].Value.TrimEnd().TrimStart().Trim('.').TrimEnd().TrimStart().Trim('.');
                county = matches.First().Groups["county"].Value.TrimEnd().TrimStart().Trim('.').TrimEnd().TrimStart().Trim('.');
            }
            //else
            //{
            //    abstract_no = "ABSTRACT NO NOT FOUND";
            //}
            matches = Regex.Matches(data, geographicIdRegexString, RegexOptions.IgnoreCase);
            if (matches.Any())
            {
                geographicid = matches.First().Groups["geoid"].Value.TrimEnd().TrimStart().Trim('.').TrimEnd().TrimStart().Trim('.').TrimEnd(Environment.NewLine.ToCharArray());
            }
            else
            {
                matches = Regex.Matches(data, alternateGeographicIdRegexString, RegexOptions.IgnoreCase);
                if (matches.Any())
                {
                    geographicid = matches.First().Groups["geoid"].Value.TrimEnd().TrimStart().Trim('.').TrimEnd().TrimStart().Trim('.').TrimEnd(Environment.NewLine.ToCharArray());
                }
                //else
                //{

                //    geographicid = "Geographic Id NOT FOUND";
                //}
            }
            matches = Regex.Matches(data, propertyIdRegexString, RegexOptions.IgnoreCase);
            if (matches.Any())
            {
                propertyid = matches.First().Groups["propid"].Value.TrimEnd().TrimStart().Trim('.').TrimEnd().TrimStart().Trim('.').TrimEnd(Environment.NewLine.ToCharArray());
            }
            else
            {
                matches = Regex.Matches(data, alternatePropertyIdRegexString, RegexOptions.IgnoreCase);
                if (matches.Any())
                {
                    propertyid = matches.First().Groups["propid"].Value.TrimEnd().TrimStart().Trim('.').TrimEnd().TrimStart().Trim('.').TrimEnd(Environment.NewLine.ToCharArray());
                }
                //else
                //{
                //    propertyid = "Property Id NOT FOUND";
                //}
            }

            dt.Rows.Add(new string[] { filename, unplatted_property, abstract_no, county, propertyid, geographicid });

        }
        dt.AcceptChanges();
        Excel(dt);

        static string ExtractFileName(string path)
        {
            var parts = path.Split('\\');
            return parts[parts.Length - 1];
        }
    }

    private static void Excel(DataTable dataTable)
    {
        var lines = new List<string>();

        string[] columnNames = dataTable.Columns
            .Cast<DataColumn>()
            .Select(column => column.ColumnName)
            .ToArray();

        var header = string.Join(",", columnNames.Select(name => $"\"{name}\""));
        lines.Add(header);

        var valueLines = dataTable.AsEnumerable()
            .Select(row => string.Join(",", row.ItemArray.Select(val => $"\"{val}\"")));

        lines.AddRange(valueLines);

        File.WriteAllLines("C:\\Users\\DELL\\source\\repos\\ConsoleApp2\\ConsoleAppParseFiles\\extracted_text\\excel.csv", lines);
    }
}