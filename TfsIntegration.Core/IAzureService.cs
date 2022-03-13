using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TfsIntegration.Core
{
    interface IAzureService
    {

        /// <summary>
        /// Получение массива идентификаторов задач Azure Dev.
        /// </summary>
        /// <returns> Список задач.</returns>
        IEnumerable<int> GetWorkItemsIds(string wiql);

        /// <summary>
        /// Получение всех задач.
        /// </summary>
        /// <param name="ids"></param>
        /// <returns> Задача. </returns>
        IEnumerable<WorkTask> GetWorkTasks(int[] ids);

        /// <summary>
        /// Получение задачи.
        /// </summary>
        /// <param name="id"> Идентификатор задачи.</param>
        /// <returns> Задача.</returns>
        IEnumerable<WorkTask> GetWorkTask(int id);

    }
}
