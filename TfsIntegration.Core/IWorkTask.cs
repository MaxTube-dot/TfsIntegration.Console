using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TfsIntegration.Core
{
    interface IWorkTask
    {
         

        /// <summary>
        /// Получение поля задачи.
        /// </summary>
        /// <param name="fieldName"> Поле которое необходимо получить.</param>
        /// <returns> Значение поля.</returns>
        object GetField(string fieldName);

        /// <summary>
        /// Получение всех полей задачи.
        /// </summary>
        /// <returns> Название полуй и их значения.</returns>
        Dictionary<string,object> GetFields();

        /// <summary>
        /// Получение всех вложений.
        /// </summary>
        /// <returns> Вложение.</returns>
        object GetAttachments();
    }
}
