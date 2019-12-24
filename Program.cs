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
            // 3.2 
            // add MenuItem in Cart
            // cart.(Juice);
            cart.AddToCart(Juice);
            cart.AddToCart(Burger);
            cart.AddToCart(Salat);
            cart.AddToCart(Water);

            SspOrder order = new SspOrder(cart);

            // change quantity
            cart.ChangeQuantity(Salat, 4);
            cart.ChangeQuantity(Juice, 2);
            cart.ChangeQuantity(Burger, 2);
            cart.ChangeQuantity(Water, 1);

            // recalculate price
            order.CalculateTotalPrice();
            
            // check our cart
            foreach (SspCartItem cartItem in cart.Cart.Values)
            {
                Console.WriteLine(cartItem.MenuItem.Name);
                Console.WriteLine(cartItem.Quantity);
            }

            // 4 Confirm with selected item
           
            // 4.2 init order service
            // check price
            Console.WriteLine(order.TotalPrice);

            // 4.3 select payment method card
            order.setPaymentMethod("card");

            // 4.4 wait a payment
            SspPaymentService paymentService = new SspPaymentService();

            paymentService.SendOnPayment(order);
        }
    }
}
