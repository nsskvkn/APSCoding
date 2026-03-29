using System;

namespace Lab_1
{
    public class ActionResult
    {
        public bool Success { get; }
        public string Message { get; }

        private ActionResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public static ActionResult Ok(string msg = "") => new(true, msg);
        public static ActionResult Fail(string msg) => new(false, msg);
    }
}