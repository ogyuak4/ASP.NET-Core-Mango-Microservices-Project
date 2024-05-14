namespace Mango.Services.CouponAPI.Models.Dto
{
    public class ResponseDto
    {
        public Object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;      //default olarak true olsun
        public string Message { get; set; } = "";
    }
}
