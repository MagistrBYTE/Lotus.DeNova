//=====================================================================================================================
// Проект: Модуль игровой вселенной DeNova
// Раздел: Подсистема аватара персонажа
// Автор: MagistrBYTE aka DanielDem <dementevds@gmail.com>
//---------------------------------------------------------------------------------------------------------------------
/** \file LotusDeNovaAvatarStateService.cs
*		Cервис для работы с аватаром персонажа.
*/
//---------------------------------------------------------------------------------------------------------------------
// Версия: 1.0.0.0
// Последнее изменение от 30.04.2023
//=====================================================================================================================
using Mapster;
using Microsoft.EntityFrameworkCore;
//---------------------------------------------------------------------------------------------------------------------
using Lotus.Repository;
//=====================================================================================================================
namespace Lotus
{
    namespace DeNova
	{
		//-------------------------------------------------------------------------------------------------------------
		/** \addtogroup DeNovaAvatarState
		*@{*/
		//-------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Cервис для работы с аватаром персонажа
		/// </summary>
		//-------------------------------------------------------------------------------------------------------------
		public class AvatarStateService : ILotusAvatarStateService
        {
            #region ======================================= ДАННЫЕ ====================================================
            private readonly ILotusRepositoryDeNova _repository;
            #endregion

            #region ======================================= КОНСТРУКТОРЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Конструктор инициализирует объект класса указанными параметрами
            /// </summary>
            /// <param name="repository">Репозиторий игровой вселенной DeNova</param>
            //---------------------------------------------------------------------------------------------------------
            public AvatarStateService(ILotusRepositoryDeNova repository)
            {
                _repository = repository;
            }
            #endregion

            #region ======================================= ОБЩИЕ МЕТОДЫ ==============================================
            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Создание аватара персонажа по указанным данным
            /// </summary>
            /// <param name="avatarInfoCreate">Параметры для создания аватара персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Аватар персонажа</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<AvatarStateDto>> CreateAsync(AvatarStateCreateRequest avatarInfoCreate, CancellationToken token)
            {
                AvatarState entity = avatarInfoCreate.Adapt<AvatarState>();

				entity.AvatarStateId = Guid.NewGuid();

				_repository.Add(entity);
                await _repository.FlushAsync(token);

                AvatarStateDto result = entity.Adapt<AvatarStateDto>();

                return XResponse.Succeed(result);
            }

            //---------------------------------------------------------------------------------------------------------
            /// <summary>
            /// Обновление данных указанного аватара персонажа
            /// </summary>
            /// <param name="avatarInfoUpdate">Параметры обновляемой аватара персонажа</param>
            /// <param name="token">Токен отмены</param>
            /// <returns>Аватар персонажа</returns>
            //---------------------------------------------------------------------------------------------------------
            public async Task<Response<AvatarStateDto>> UpdateAsync(AvatarStateDto avatarInfoUpdate, CancellationToken token)
            {
                AvatarState entity = avatarInfoUpdate.Adapt<AvatarState>();

                _repository.Update(entity);
                await _repository.FlushAsync(token);

                AvatarStateDto result = entity.Adapt<AvatarStateDto>();

                return XResponse.Succeed(result);
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение указанного аватара персонажа
			/// </summary>
			/// <param name="avatarInfoId">Идентификатор аватара персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Аватар персонажа</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response<AvatarStateDto>> GetAsync(Guid avatarInfoId, CancellationToken token)
			{
				AvatarState? entity = await _repository.Query<AvatarState>()
					.FirstOrDefaultAsync(x => (x.AvatarStateId == avatarInfoId && x.GameSaveId == null), token);
				if (entity == null)
				{
					return XResponse.Failed<AvatarStateDto>(XAvatarStateErrors.NotFound);
				}

				AvatarStateDto result = entity.Adapt<AvatarStateDto>();

				return XResponse.Succeed(result);
			}

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Получение списка аватаров персонажа 
			/// </summary>
			/// <param name="avatarInfoRequest">Параметры получения списка</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Список аватаров персонажа </returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<ResponsePage<AvatarStateDto>> GetAllAsync(AvatarStatesDto avatarInfoRequest, CancellationToken token)
            {
                var query = _repository.Query<AvatarState>();

				query = query
					.Where(x => x.GameId == avatarInfoRequest.GameId &&
								x.PersonId == avatarInfoRequest.PersonId &&
								x.GameSaveId == null);

				query = query.Filter(avatarInfoRequest.Filtering);

				var queryOrder = query.Sort(avatarInfoRequest.Sorting, x => x.BeginPeriod);

				var result = await queryOrder.ToResponsePageAsync<AvatarState, AvatarStateDto>(avatarInfoRequest, token);

                return result;
            }

			//---------------------------------------------------------------------------------------------------------
			/// <summary>
			/// Удаление аватара персонажа
			/// </summary>
			/// <param name="avatarInfoId">Идентификатор аватара персонажа</param>
			/// <param name="token">Токен отмены</param>
			/// <returns>Статус успешности</returns>
			//---------------------------------------------------------------------------------------------------------
			public async Task<Response> DeleteAsync(Guid avatarInfoId, CancellationToken token)
            {
                AvatarState? entity = await _repository.Query<AvatarState>()
					.FirstOrDefaultAsync(x => (x.AvatarStateId == avatarInfoId && x.GameSaveId == null), token);
                if (entity == null)
                {
                    return XResponse.Failed(XAvatarStateErrors.NotFound);
                }

                _repository.Remove(entity!);
                await _repository.FlushAsync(token);

                return XResponse.Succeed();
            }
            #endregion
        }
        //-------------------------------------------------------------------------------------------------------------
        /**@}*/
        //-------------------------------------------------------------------------------------------------------------
    }
}
//=====================================================================================================================