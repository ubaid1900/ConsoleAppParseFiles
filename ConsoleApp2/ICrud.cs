public interface ICrud<T, TId>
{
    public TId Create(T newEntity);
    public TId Update(TId id, T updatedEntity);
    public TId Delete(TId id);
    public T Read(TId id);
    public T[] ReadAll();
}

// Encapsulation, hide internal state

// static
// Access Modifier: private (accesible with the class), internal (accessible within the same assembly), public, protected (accessible to inheriting type)


public class ConcreteOfInterfaceCrud<T, TKey> : ICrud<T, TKey>
{
    TKey ICrud<T, TKey>.Create(T newEntity)
    {
        throw new NotImplementedException();
    }

    TKey ICrud<T, TKey>.Delete(TKey id)
    {
        throw new NotImplementedException();
    }

    T ICrud<T, TKey>.Read(TKey id)
    {
        throw new NotImplementedException();
    }

    T[] ICrud<T, TKey>.ReadAll()
    {
        throw new NotImplementedException();
    }

    TKey ICrud<T, TKey>.Update(TKey id, T updatedEntity)
    {
        throw new NotImplementedException();
    }
}

