using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace common
{
    [Serializable]
    public enum DataMethodsType
    {
        Undefined,
        SendName,
        SendMessageToServer,
        SendMessageToAll,
        RemoteDesktop,
        LCLICK,
        RCLICK,
        LDCLICK,
        RDCLICK,
        LDOWN,
        RDOWN,
        LUP,
        RUP,
        MOVE,
        KEYPRESS,
        KEYUP,
        KEYDOWN,
        Shutdown,
        Restart,
        LockMouseAndKeyBoard,
        LockScreen,
        UnlockScreen,
        Exit,
        ExitRemote
    }


    [Serializable]
    public class DataMethods
    {
        public DataMethodsType Type { get; set; }
        public object Data { get; set; }

        public DataMethods()
        {
            Type = DataMethodsType.Undefined;
            Data = null;
        }

        public DataMethods(DataMethodsType type, object data)
        {

            Data = data;
            Type = type;
        }

        /// <summary>
        /// phân mảnh 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public byte[] Serialize()
        {
            try
            {
                MemoryStream stream = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                //ghi lên hết tờ giấy stream
                formatter.Serialize(stream, this);
                //biến tờ giấy thành một mảng để gửi nó đi
                return stream.ToArray();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// gom mảnh lại
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataMethods Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            object obj = formatter.Deserialize(stream);
            return obj as DataMethods;
        }
    }
}
