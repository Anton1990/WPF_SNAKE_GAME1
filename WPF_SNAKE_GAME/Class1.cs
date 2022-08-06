using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_SNAKE_GAME
{
    internal class Model
    {

        public bool crossing(List<string> arr_input_1, List<string> arr_input_2)

        {

            var arr_index_1 = new List<string> { };
            var arr_index_2 = new List<string> { };

            var query = arr_input_1.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();

            for (int i = 0; i < arr_input_1.Count(); i++)
            {
                for (int j = 0; j < query.Count(); j++)
                {

                    if (arr_input_1[i] == query[j])
                        arr_index_1.Add(i.ToString());

                }
            }
            //----------------------------------

            query.Clear();
            query = arr_input_2.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();

            for (int i = 0; i < arr_input_2.Count(); i++)
            {
                for (int j = 0; j < query.Count(); j++)
                {

                    if (arr_input_2[i] == query[j])
                        arr_index_2.Add(i.ToString());

                }
            }

            var result = arr_index_2.Intersect(arr_index_1);
            return result.Count() > 0;


            //Вариант вызова метода
            //   var arr_input_11 = new List<int> { 1, 11, 3, 4, 5, 6, 1, 8, 9, 1 };
            //   var arr_input_12 = new List<int> { 7, 1, 3, 4, 5, 6, 7, 8, 9, 1 };
            //  Trace.WriteLine(crossing(  arr_input_11.ConvertAll<string>(x => x.ToString()),  arr_input_12.ConvertAll<string>(x => x.ToString()))       );

            //----Работа с Хэш показывает дублткаты в List

            /*var list = new List<int>() {1,2,3,4,77,1,1};

            var indexes = list.Select((item, index) => new { Item = item, Index = index })
                              .Where(n => !hashset.Add(n.Item)
            )
                              .Select(n => n.Index);
            Trace.WriteLine("Even numbers:");


            foreach (var person in indexes)
                Trace.WriteLine(person);
            */
            

        }









    }
}
