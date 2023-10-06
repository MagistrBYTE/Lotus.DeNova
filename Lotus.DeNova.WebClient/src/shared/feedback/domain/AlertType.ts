
/**
 * Перечисление для типа простого информирования
 */
export const AlertTypeEnum =
{
  /**
   * Ошибка
   */
  Error:
  {
    id: 0,
    name: 'error' 
  },

  /**
   * Предупреждение
   */
  Warning:
  {
    id: 1,
    name: 'warning' 
  },  

  /**
   * Простая информация
   */
  Info:
  {
    id: 2,
    name: 'info' 
  },

  /**
   * Простая информация со статусом успешно
   */
  Success:
  {
    id: 3,
    name: 'Success' 
  }
} as const;

/**
 * Тип простого информирования
 */
export type TAlertType = keyof typeof AlertTypeEnum;