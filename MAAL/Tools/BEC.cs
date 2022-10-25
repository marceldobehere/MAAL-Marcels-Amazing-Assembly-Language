using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAAL.Tools
{
    public class BEC //ByteEndianConverter
    {
        public static bool needToSwitch = BitConverter.IsLittleEndian;

        static byte[] SwitchByteArr(byte[] data)
        {
            byte[] newData = new byte[data.Length];
            for (int i = 0; i < data.Length; i++)
                newData[i] = data[(data.Length - i) - 1];

            return newData;
        }

        static byte[] SwitchByteArr(byte[] data, int start, int count, bool switchArr)
        {
            byte[] newData = new byte[count];
            if (!switchArr)
                for (int i = 0; i < count; i++)
                    newData[i] = data[(start + count - 1) - i];
            else
                for (int i = 0; i < count; i++)
                    newData[i] = data[start + i];

            return newData;
        }

        public static ulong ByteArrToUint64(byte[] arr, int startIndex)
        {
            arr = SwitchByteArr(arr, startIndex, 8, needToSwitch);
            return BitConverter.ToUInt64(arr, 0);
        }

        public static uint ByteArrToUint32(byte[] arr, int startIndex)
        {
            arr = SwitchByteArr(arr, startIndex, 4, needToSwitch);
            return BitConverter.ToUInt32(arr, 0);
        }

        public static ushort ByteArrToUint16(byte[] arr, int startIndex)
        {
            arr = SwitchByteArr(arr, startIndex, 2, needToSwitch);
            return BitConverter.ToUInt16(arr, 0);
        }

        public static byte[] UInt64ToByteArr(ulong val)
        {
            byte[] arr = BitConverter.GetBytes(val);
            if (needToSwitch)
                arr = SwitchByteArr(arr);
            return arr;
        }
        public static byte[] UInt32ToByteArr(uint val)
        {
            byte[] arr = BitConverter.GetBytes(val);
            if (needToSwitch)
                arr = SwitchByteArr(arr);
            return arr;
        }
        public static byte[] UInt16ToByteArr(ushort val)
        {
            byte[] arr = BitConverter.GetBytes(val);
            if (needToSwitch)
                arr = SwitchByteArr(arr);
            return arr;
        }

        public static byte[] Int64ToByteArr(long val)
        {
            byte[] arr = BitConverter.GetBytes(val);
            if (needToSwitch)
                arr = SwitchByteArr(arr);
            return arr;
        }
        public static byte[] Int32ToByteArr(int val)
        {
            byte[] arr = BitConverter.GetBytes(val);
            if (needToSwitch)
                arr = SwitchByteArr(arr);
            return arr;
        }
        public static byte[] Int16ToByteArr(short val)
        {
            byte[] arr = BitConverter.GetBytes(val);
            if (needToSwitch)
                arr = SwitchByteArr(arr);
            return arr;
        }
        public static byte[] FloatToByteArr(float val)
        {
            byte[] arr = BitConverter.GetBytes(val);
            if (needToSwitch)
                arr = SwitchByteArr(arr);
            return arr;
        }
        public static byte[] DoubleToByteArr(double val)
        {
            byte[] arr = BitConverter.GetBytes(val);
            if (needToSwitch)
                arr = SwitchByteArr(arr);
            return arr;
        }

        public static int ByteArrIntoArr(byte[] baseArr, byte[] dataArr, int startIndex)
        {
            if (needToSwitch)
                dataArr = SwitchByteArr(dataArr);

            for (int i = 0; i < dataArr.Length; i++)
                baseArr[i + startIndex] = dataArr[i];

            return dataArr.Length;
        }
    }
}
