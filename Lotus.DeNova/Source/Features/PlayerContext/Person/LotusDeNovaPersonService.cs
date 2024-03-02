using Lotus.Repository;

using Mapster;

using Microsoft.EntityFrameworkCore;

namespace Lotus.DeNova
{
    /** \addtogroup DeNovaPerson
	*@{*/
    /// <summary>
    /// Cервис для работы с персонажами.
    /// </summary>
    public class PersonService : ILotusPersonService
    {
        #region Fields
        private readonly ILotusDataStorageDeNova _dataStorage;
        private readonly ILotusResourceFileService _imageService;
        #endregion

        #region Constructors
        /// <summary>
        /// Конструктор инициализирует объект класса указанными параметрами.
        /// </summary>
        /// <param name="dataStorage">Репозиторий игровой вселенной DeNova.</param>
        /// <param name="imageService">Интерфейс сервиса для работы с файлами.</param>
        public PersonService(ILotusDataStorageDeNova dataStorage, ILotusResourceFileService imageService)
        {
            _dataStorage = dataStorage;
            _imageService = imageService;
        }
        #endregion

        #region ILotusPersonService methods
        /// <inheritdoc/>
        public async Task<Response<PersonDto>> CreateAsync(PersonCreateRequest personCreate, CancellationToken token)
        {
            var entity = personCreate.Adapt<Person>();

            if (personCreate.AvatarId.HasValue && personCreate.IsLocalAvatar.GetValueOrDefault())
            {
                var imageDto = new FileCreateLocalRequest()
                {
                    Id = personCreate.AvatarId.Value,
                };
                await _imageService.CreateAsync(imageDto, token);
            }

            _dataStorage.Add(entity);

            _dataStorage.Add(entity.PhysicalStrength);
            _dataStorage.Add(entity.Dexterity);
            _dataStorage.Add(entity.Endurance);
            _dataStorage.Add(entity.Physique);

            _dataStorage.Add(entity.Perception);
            _dataStorage.Add(entity.Mind);
            _dataStorage.Add(entity.Willpower);
            _dataStorage.Add(entity.Spirituality);

            _dataStorage.Add(entity.Appearance);
            _dataStorage.Add(entity.Charisma);
            _dataStorage.Add(entity.Influence);
            _dataStorage.Add(entity.Status);

            await _dataStorage.SaveChangesAsync(token);

            entity.SetPersonId();

            _dataStorage.Update(entity.PhysicalStrength);
            _dataStorage.Update(entity.Dexterity);
            _dataStorage.Update(entity.Endurance);
            _dataStorage.Update(entity.Physique);

            _dataStorage.Update(entity.Perception);
            _dataStorage.Update(entity.Mind);
            _dataStorage.Update(entity.Willpower);
            _dataStorage.Update(entity.Spirituality);

            _dataStorage.Update(entity.Appearance);
            _dataStorage.Update(entity.Charisma);
            _dataStorage.Update(entity.Influence);
            _dataStorage.Update(entity.Status);

            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<PersonDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<PersonDto>> UpdateAsync(PersonDto personUpdate, CancellationToken token)
        {
            var entity = personUpdate.Adapt<Person>();

            if (personUpdate.AvatarId.HasValue && personUpdate.IsLocalAvatar.GetValueOrDefault())
            {
                var imageDto = new FileCreateLocalRequest()
                {
                    Id = personUpdate.AvatarId.Value,

                };
                await _imageService.CreateAsync(imageDto, token);
            }

            _dataStorage.Update(entity);
            await _dataStorage.SaveChangesAsync(token);

            var result = entity.Adapt<PersonDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<Response<PersonDto>> GetAsync(Guid id, CancellationToken token)
        {
            var entity = await _dataStorage.Query<Person>()
                .Include(x => x.Avatar)
                .FirstOrDefaultAsync(x => x.Id == id, token);

            if (entity == null)
            {
                return XResponse.Failed<PersonDto>(XPersonErrors.NotFound);
            }

            var result = entity.Adapt<PersonDto>();

            return XResponse.Succeed(result);
        }

        /// <inheritdoc/>
        public async Task<ResponsePage<PersonDto>> GetAllAsync(PersonsRequest personRequest, CancellationToken token)
        {
            var query = _dataStorage.Query<Person>();

            query = query.Include(x => x.Avatar).Filter(personRequest.Filtering);

            var queryOrder = query.Sort(personRequest.Sorting, x => x.Id);

            var result = await queryOrder.ToResponsePageAsync<Person, PersonDto>(personRequest, token);

            return result;
        }

        /// <inheritdoc/>
        public async Task<Response> DeleteAsync(Guid id, CancellationToken token)
        {
            var entity = await _dataStorage.GetByIdAsync<Person, Guid>(id, token);
            if (entity == null)
            {
                return XResponse.Failed(XPersonErrors.NotFound);
            }

            _dataStorage.Remove(entity!);
            await _dataStorage.SaveChangesAsync(token);

            return XResponse.Succeed();
        }
        #endregion
    }
    /**@}*/
}