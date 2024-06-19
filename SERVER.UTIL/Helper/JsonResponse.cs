namespace SERVER.UTIL.Helper
{
    public class JsonResponse
    {
        private bool _IsSuccess = false;
        public bool IsSuccess
        {
            get { return _IsSuccess; }
            set { _IsSuccess = value; }
        }

        private bool _IsValid = false;
        public bool IsValid
        {
            get { return _IsValid; }
            set { _IsValid = value; }
        }

        private string _Message = string.Empty;
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

        private string _Token = string.Empty;
        public string Token
        {
            get { return _Token; }
            set { _Token = value; }
        }

        private bool _IsToken = false;
        public bool IsToken
        {
            get { return _IsToken; }
            set { _IsToken = value; }
        }

        private int _Status = 404;
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public object? Result { get; set; } = null;

        private string _Error = string.Empty;
        public string Error
        {
            get { return _Error; }
            set { _Error = value; }
        }
    }
}
