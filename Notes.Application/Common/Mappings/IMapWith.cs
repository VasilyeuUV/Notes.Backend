using AutoMapper;

namespace Notes.Application.Common.Mappings
{
    /// <summary>
    /// Контракт для маппинга
    /// </summary>
    public interface IMapWith<T>
    {
        /// <summary>
        /// Маппинг
        /// </summary>
        /// <param name="profile"></param>
        void Mapping(Profile profile)
            => profile.CreateMap(typeof(T), GetType());
    }
}
