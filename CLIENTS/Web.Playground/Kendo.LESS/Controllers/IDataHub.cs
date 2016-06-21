using BusinessObjects;

namespace Kendo.LESS
{
    public interface IDataHub
    {
        void Create(Data data);
        void Read();
        void Update(Data data);
        void Delete(Data data);

    }
}