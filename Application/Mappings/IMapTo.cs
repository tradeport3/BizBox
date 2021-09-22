using AutoMapper;

namespace Application.Mappings
{
    public interface IMapTo<T>
    {
        void Mapping(Profile mapper) => mapper.CreateMap(this.GetType(), typeof(T));
    }
}
