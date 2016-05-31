using System;
using System.Text;

namespace CSharpNote.Data.Project.Implement.ResultData
{
    public class ResultData
    {
        #region Field

        private readonly bool success;
        private readonly string message;
        private readonly object data;

        #endregion

        #region Constructor

        public ResultData()
        {
        }

        public ResultData(Exception exception, string extraInfo = "")
        {
            success = false;

            var sb = new StringBuilder();
            sb.Append(string.Format("Exception:{0}", exception.Message));
            if (extraInfo != string.Empty)
            {
                sb.Append(string.Format("ExtraInfo:{0}", extraInfo));
            }

            message = sb.ToString();
        }

        public ResultData(bool success, string message = "", object data = null)
        {
            this.success = success;
            this.message = message;
            this.data = data;
        }

        #endregion

        #region Property

        public bool Success
        {
            get { return success; }
        }

        public string Message
        {
            get { return message; }
        }

        public object Data
        {
            get { return data; }
        }

        #endregion

        #region MyRegion

        public override string ToString()
        {
            return message;
        }

        public T GetData<T>()
        {
            return (T) data;
        }

        #endregion

        #region Type Conversion

        public static implicit operator bool(ResultData result)
        {
            return result.success;
        }

        public static implicit operator string(ResultData result)
        {
            return result.message;
        }

        public static implicit operator ResultData(string result)
        {
            return new ResultData(result == string.Empty, result);
        }

        public static implicit operator ResultData(bool result)
        {
            return new ResultData(result);
        }

        #endregion
    }
}