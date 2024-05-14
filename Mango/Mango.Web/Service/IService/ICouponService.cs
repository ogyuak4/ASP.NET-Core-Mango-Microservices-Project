using Mango.Web.Models;

namespace Mango.Web.Service.IService
{
    public interface ICouponService
    {
        Task<ResponseDto?> GetCouponAsync(string couponCode);
        Task<ResponseDto?> GetAllCouponsAsync();
        Task<ResponseDto?> GetCouponByIdAsync(int id);
        Task<ResponseDto?> CreateCouponsAsync(CouponDto coupondto);
        Task<ResponseDto?> UpdateCouponsAsync(CouponDto coupondto);
        Task<ResponseDto?> DeleteCouponsAsync(int id);


    }
}
