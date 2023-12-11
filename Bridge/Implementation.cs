using System.Diagnostics.Tracing;

namespace Bridge
{
    /// <summary>
    /// Abstraction
    /// </summary>
    public abstract class Menu
    {
        public readonly ICoupon _coupon = null!;
        public abstract int CalculatePrice();

        public Menu(ICoupon coupon)
        {
            _coupon = coupon;
        }
    }
    
    /// <summary>
    /// Refined Abstraction
    /// </summary>
    public class VegetarianMenu : Menu
    {
        public VegetarianMenu(ICoupon coupon) : base(coupon)
        {
            
        }

        public override int CalculatePrice()
        {
            return 20 - _coupon.CouponValue;
        }
    }
    
    /// <summary>
    /// Refined Abstraction
    /// </summary>
    public class MeatBasedMenu : Menu
    {
        public MeatBasedMenu(ICoupon coupon) : base(coupon)
        {
            
        }

        public override int CalculatePrice()
        {
            return 30 - _coupon.CouponValue;
        }
    }

    /// <summary>
    /// Implementor
    /// </summary>
    public interface ICoupon
    {
        public abstract int CouponValue { get; }
    }
    
    /// <summary>
    /// Concrete Implementor
    /// </summary>
    public class NoCoupon : ICoupon
    {
        public int CouponValue { get; }
    }
    
    /// <summary>
    /// Concrete Implementor
    /// </summary>
    public class OneEuroCoupon : ICoupon
    {
        public int CouponValue
        {
            get => 1;
        }
    }
    
    /// <summary>
    /// Concrete Implementor
    /// </summary>
    public class TwoEuroCoupon : ICoupon
    {
        public int CouponValue
        {
            get => 2;
        }
    }
}