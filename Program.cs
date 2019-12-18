using SelfServiceTerminal.DomainModel;
using SelfServiceTerminal.Services;
using System;

namespace SelfServiceTerminal
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 1 add MenuItem
            var Burger = new SspMenuItem("burger", true, 100);
            var Salat = new SspMenuItem("salat", true, 150);
            var Potatoes = new SspMenuItem("potatoes", true, 200);
            var Juice = new SspMenuItem("juice", true, 50);
            var Water = new SspMenuItem("water", true, 80);

            // 2 generate Menu
            SspMenu Menu = new SspMenu();

            Menu.AddMenuItem(Burger);
            Menu.AddMenuItem(Salat);
            Menu.AddMenuItem(Potatoes);
            Menu.AddMenuItem(Juice);
            Menu.AddMenuItem(Water);
            foreach (SspMenuItem item in Menu._menu)
            {
                Console.WriteLine(item.Name);
            }
            // e-commerce part
            // 3 added menuItem flow
            
            // 3.1 init cart
            SspCart cart = new SspCart();
            // 3.2 init cartService
            SspCartService serviceCart = new SspCartService(ref cart, Menu);

            // add MenuItem in Cart
            serviceCart.AddMenuItem(Juice);
            serviceCart.AddMenuItem(Salat);

            // change quantity
            serviceCart.ChangeQuantity(Salat, 4);
            serviceCart.ChangeQuantity(Juice, 2);
            
            // check our cart
            foreach (Guid id in cart.Cart.Keys)
            {
                SspMenuItem menuItemInCart = serviceCart.GetMenuItemById(id);
                Console.WriteLine(menuItemInCart.Name, " - ", menuItemInCart.Price);
            }
            
            // 4 Confirm with selected item

            // 4.1 init order
            SspOrder order = new SspOrder(ref cart);

            // 4.2 init order service
            SspOrderService orderService = new SspOrderService(ref order, ref serviceCart);
            // check price
            Console.WriteLine(orderService.GetTotalPriceOrder());

            // 4.3 select payment method card
            order.setPaymentMethod("card");

            // 4.4 wait a payment
            orderService.SendOnPayment();
        }
    }
}
