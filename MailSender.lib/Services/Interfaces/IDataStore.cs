using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Services.Interfaces
{
    /// <summary>
    /// Хранилище объектов
    /// </summary>
    /// <typeparam name="T">Тип хранимого объекта</typeparam>
    public interface IDataStore<T>
    {
        /// <summary>
        /// Получить все объекты
        /// </summary>
        /// <returns>Перечисление объектов</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Получить объект по идентификатору
        /// </summary>
        /// <param name="id">.идентификатор объекта</param>
        /// <returns>Найденный объект или null</returns>
        T GetById(int id);

        /// <summary>
        /// Создать объект
        /// </summary>
        /// <param name="item">Создаваемый объект</param>
        /// <returns>Id созданного объекта</returns>
        int Create(T item);

        /// <summary>
        /// Редактировать объект
        /// </summary>
        /// <param name="id">Id редактируемого объекта</param>
        /// <param name="item">Редактируемый объект</param>
        void Edit(int id, T item);

        /// <summary>
        /// Удалить объект
        /// </summary>
        /// <param name="id">Id удаляемого объекта</param>
        /// <returns>Удалённый объект или null</returns>
        T Remove(int id);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void SaveChanges();
    }
}
