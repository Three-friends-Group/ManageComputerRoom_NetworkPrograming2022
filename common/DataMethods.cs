using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    public class DataMethods
    {
        /// <summary>
        /// phân mảnh 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();

            BinaryFormatter formatter = new BinaryFormatter();

            //ghi lên hết tờ giấy stream
            formatter.Serialize(stream, obj);
            //biến tờ giấy thành một mảng để gửi nó đi
            return stream.ToArray();
        }

        /// <summary>
        /// gom mảnh lại
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }
    }
}
