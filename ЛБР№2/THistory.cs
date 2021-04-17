using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__2_ТРПО.ЛБР_2
{
    class THistory

    {

        /*Список записей*/

        private List<string> list;

        /*Кол-во записей*/

        public int size = 0;

        /*Конструктор*/

        public THistory()

        {

            list = new List<string>();

        }

        /*Добавить запись в историю*/

        public void AddRecord(string rec)

        {

            list.Add(rec);

            size++;

        }

        /*Очистить историю*/

        public void ClearHistory()

        {

            list.Clear();

            size = 0;

        }

        /*Взять запись по ее номеру*/

        public string GetRecordByIndex(int i)

        {

            if (size != 0)

                return list[i];

            else

                return "";

        }

        /*Удалить запись*/

        public void RemoveRecordByIndex(int i)

        {

            list.RemoveAt(i);

            size--;

        }

    }
}
