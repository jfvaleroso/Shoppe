namespace Exchange.Core.Services.IServices
{
    public interface IValidateService<TEntity>
    {
        bool CheckDataIfExists(TEntity entity);

        bool CheckDataIfExists(string param);
    }
}