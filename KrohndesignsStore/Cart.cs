using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart{

    public class Cart{
        private List<KrohndesignsStore.Pair<Item, int>> items;
        private double totalPrice;
        private double totalShippingPrice;

        // DEFAULT CONSTRUCTOR
        public Cart(){
            items = new List<KrohndesignsStore.Pair<Item, int>>();
        }

        // CONSTRUCTOR - takes a List of KrohndesignsStore.Pair items to add to an empty shopping cart. 
        public Cart(List<KrohndesignsStore.Pair<Item, int>> newItems){
            items = new List<KrohndesignsStore.Pair<Item,int>>(newItems);
        }

        // Empty the shopping cart and set the pricing totals to zero.
        public void emptyCart(){
            items.Clear();
            totalPrice = 0.00;
            totalShippingPrice = 0.00;
        }

        public double getTotalPrice(){
            return totalPrice;
        }

        public double getTotalShipping(){
            return totalShippingPrice;
        }

        public int itemCount(){
            return items.Count();
        }

        public KrohndesignsStore.Pair<Item,int> getItem(int index){
            if(index < 0 || index > items.Count()){
                throw new Exception("Invalid index to getItem()");
            }

            return items[index];
        }

        /************************************************************  
         * Adds a new Item to the Collection of Items in the current order.
         ************************************************************/
        public void addItem(Item newItem){
            // check if this item already exists in the cart, if it does add another.
            bool itemFound = false;
            foreach(KrohndesignsStore.Pair<Item, int> entry in items){
                if(entry.itemOne.getItemNumber() == newItem.getItemNumber()) {
                    entry.itemTwo++;
                    itemFound = true;   // keep track of if the item already exists.
                }
            }

            // if the item isn't in the cart then add it.
            if(!itemFound){
                items.Add(new KrohndesignsStore.Pair<Item, int>(newItem, 1));
            }

            totalPrice += newItem.getPrice();
            totalShippingPrice += newItem.getShipping();
        }

        /************************************************************
         * The checkout method removes all the items from the shopping cart
        * and returns a collection of all the purchased items so they
        * can be displayed on the order confirmation screen.
        ************************************************************/ 
        //TODO: write the order to a "previous orders" database.
        public List<KrohndesignsStore.Pair<Item, int>> checkout(){
            List<KrohndesignsStore.Pair<Item, int>> purchasedItems = new List<KrohndesignsStore.Pair<Item, int>>(items);
            // TODO: update stock count when items are purchased.
            items.Clear();
            totalPrice = 0;
            totalShippingPrice = 0;
            return purchasedItems;
        }

        /************************************************************
         * Completely removes all of an item from the shopping cart.
         ************************************************************/ 
        public bool removeItem(int itemNumber){
            // remove the item if itemNumbers match.
            foreach(KrohndesignsStore.Pair<Item, int> entry in items){
                if(entry.itemOne.getItemNumber() == itemNumber){
                    // adjust the shipping and total price values.
                    totalPrice -= (entry.itemOne.getPrice() * entry.itemTwo);
                    totalShippingPrice -= (entry.itemOne.getShipping() * entry.itemTwo);
                    items.Remove(entry);
                    return true;
                }
            }
            // return false if the item wasn't found.
            return false;
        }

        /************************************************************ 
         * Add 'amount' of the specified item to the cart.
         ************************************************************/
        public bool increaseQuantity(int amount, int itemNumber){
            // add 'amount' if the itemNumbers match.
            foreach(KrohndesignsStore.Pair<Item, int> entry in items){
                if(entry.itemOne.getItemNumber() == itemNumber){
                    entry.itemTwo += amount;
                    totalPrice += entry.itemOne.getPrice() * amount;
                    totalShippingPrice += entry.itemOne.getShipping() * amount;
                    return true;
                }
            }
            // return false if the item wasn't found.
            return false;
        }

        /************************************************************
         * Add 'amount' of the specified item to the cart.
         ************************************************************/
        public bool decreaseQuantity(int amount, int itemNumber){
            // subtract 'amount' if the itemNumbers match.
            foreach(KrohndesignsStore.Pair<Item, int> entry in items){
                if(entry.itemOne.getItemNumber() == itemNumber){
                    // if this will remove all copies of the item, just remove it completely.
                    if(amount >= entry.itemTwo){
                        removeItem(itemNumber);
                    }
                    else {
                        entry.itemTwo -= amount;
                        totalPrice -= entry.itemOne.getPrice() * amount;
                        totalShippingPrice -= entry.itemOne.getShipping() * amount;
                    }
                    return true;
                }
            }
            // return false if the item wasn't found.
            return false;
        }

        /************************************************************
         * Add 'amount' of the specified item to the cart.
         ************************************************************/
        public bool setQuantity(int quantity, int itemNumber){
            // check that new quantity is a positive number.
            if(quantity < 0){
                return false;
            }
            foreach(KrohndesignsStore.Pair<Item, int> entry in items){
                if(entry.itemOne.getItemNumber() == itemNumber){
                    // remove the old price/shipping costs from the cart total.
                    totalPrice -= entry.itemOne.getPrice() * entry.itemTwo;
                    totalShippingPrice -= entry.itemOne.getShipping() * entry.itemTwo;
                    // update the quantity.
                    entry.itemTwo = quantity;
                    // update the new price/shipping total.
                    totalPrice += entry.itemOne.getPrice() * entry.itemTwo;
                    totalShippingPrice += entry.itemOne.getShipping() * entry.itemTwo;
                    return true;
                }
            }
            // return false if the item wasn't found.
            return false;
        }

        /************************************************************
         * Overridden ToString() function
         ************************************************************/
        public override string ToString(){
            int itemCount = 0;
            string returnString = string.Format("Total Price: ${0}\nTotalShipping: ${1}\nItems in cart:\n\t", totalPrice, totalShippingPrice);
            foreach(KrohndesignsStore.Pair<Item, int> entry in items){
                returnString += string.Format("{0}. {1}\n\t\tCount: {2}\n\n\t", ++itemCount, entry.itemOne.ToString(), entry.itemTwo);
            }
            return returnString;
        }
    }

    /************************************************************
     *  The Item class represents any item that can be added to a Cart.
     ************************************************************/
    public class Item{
        public enum Item_Type {Board, Box, Sconce, Sign, Organizer, JarSconce};
        public enum Stain_Color {Red, DarkRed, Gray, Walnut, Ebony, White};
        protected double price;
        protected double shippingPrice;
        private int stock;
        protected int itemNumber;
        private Item_Type type;
        private Stain_Color stain;

        public Item(double price, double shippingPrice, Item_Type type, Stain_Color stain) {

            this.price = price;
            this.shippingPrice = shippingPrice;
            this.stock = -1;    // set to -1 because this var isn't currently being used.
            this.itemNumber = -999; // item number determined by child class, -999 denotes no item number assigned.
            this.type = type;
            this.stain = stain;
        }
        
        public void setCost(double price, double shipping){
            this.price = price;
            this.shippingPrice = shipping;
        }

        public double getPrice(){
            return price;
        }

        public double getShipping(){
            return shippingPrice;
        }

        public int getStock(){
            return stock;
        }

        public int getItemNumber(){
            return itemNumber;
        }

        public Item_Type getType(){
            return type;
        }

        public Stain_Color getStain(){
            return stain;
        }

        public string getStainString() {
            string stainColor;
            switch(stain){
                case Stain_Color.DarkRed:
                    stainColor = "Dark Red Mahogany";
                    break;
                case Stain_Color.Ebony:
                    stainColor = "Ebony";
                    break;
                case Stain_Color.Gray:
                    stainColor = "Gray";
                    break;
                case Stain_Color.Red:
                    stainColor = "Red Mahogany";
                    break;
                case Stain_Color.Walnut:
                    stainColor = "Walnut";
                    break;
                case Stain_Color.White:
                    stainColor = "White";
                    break;
                default:
                    stainColor = "error";
                    break;
            }
            return stainColor;
        }

        public override string ToString(){
            return string.Format("Price: ${0}, Shipping: ${1}, Item Number: {2}\n\t", price, shippingPrice, itemNumber);
        }

        virtual public string toDataString(){
            return "";
        }
    }

    /************************************************************
     *  The Chalkboard class is a subclass of the Item class.
     ************************************************************/
    public class Chalkboard : Item {
        public enum Magnetic_Type {Magnetic, NonMagnetic};
        public enum Frame_Style {Mitered, Straight};
        public enum Hanging_Direction {Horizontal, Vertical, Both};

        private double length;
        private double width;
        private Magnetic_Type magnetic;
        private Frame_Style frameStyle;
        private Hanging_Direction direction;

        // Constructor
        public Chalkboard(double price, double shippingPrice, Item.Item_Type type, 
                          Item.Stain_Color stain, double length, double width, Magnetic_Type mag, Frame_Style frame, Hanging_Direction dir)
                          : base(price, shippingPrice, type, stain){
            this.length = length;
            this.width = width;
            this.magnetic = mag;
            this.frameStyle = frame;
            this.direction = dir;
            itemNumber = KrohndesignsStore.ItemNumberGenerator.getItemNumber(this);
        }

        public double getLength(){
            return length;
        }

        public double getWidth(){
            return width;
        }

        public Magnetic_Type getMagneticType(){
            return magnetic;
        }

        public Frame_Style getFrameStyle(){
            return frameStyle;
        }

        public Hanging_Direction getHangingDirection(){
            return direction;
        }

        public bool isMagnetic(){ 
            if(magnetic == Magnetic_Type.Magnetic){
                return true;
            }
            return false;
        }

        public override string ToString(){
            // create strings to indicate magnetic, frame style and hanging direction.
            string mag = (magnetic == Magnetic_Type.Magnetic) ? "Magnetic":"Non-Magnetic";
            string frame = (frameStyle == Frame_Style.Mitered) ? "Mitered":"Straight";
            string hang = (direction == Hanging_Direction.Both ? "Both":((direction == Hanging_Direction.Horizontal) ? "Horizontal":"Vertical"));
            string stain = base.getStainString(); 
            return string.Format("Chalkboard: {0}x{1}, {2}, {3}, {4}, {5}", length, width, stain, mag, frame, hang);
        }
        
        // Creates a parsable string to represent the chalkboard. Used for string in database.
        public override string toDataString(){
            return string.Format("{0},{1},{2}/", itemNumber, price, shippingPrice);
        }
    }

    /************************************************************
     *  The Sconce class is a subclass of the Item class.
     ************************************************************/
    public class Sconce : Item{
        double height;

        public Sconce(double price, double shippingPrice, Item.Item_Type type, 
                      Item.Stain_Color stain, double height): base(price, shippingPrice, type, stain){
            this.height= height;
            itemNumber = KrohndesignsStore.ItemNumberGenerator.getItemNumber(this);
        }

        public double getHeight(){
            return height;
        }

        public override string ToString()
        {
            string stain = base.getStainString();
            return string.Format("Sconces: {0}\" Height, {1}", height, stain);
        }

		public override string toDataString(){
			return string.Format("{0},{1},{2}/", itemNumber, price, shippingPrice);
		}
    }

    /************************************************************
     *  The Box class is a subclass of the Item class.
     ************************************************************/
    public class Box : Item{
        double length;

        public Box(double price, double shippingPrice, Item.Item_Type type, 
                      Item.Stain_Color stain, double length): base(price, shippingPrice, type, stain){
            this.length = length;
            itemNumber = KrohndesignsStore.ItemNumberGenerator.getItemNumber(this);
        }

        public double getLength(){
            return length;
        }

        public override string ToString()
        {
            string stain = base.getStainString();
            return string.Format("Wedding Box: {0}\" Length, {1}", length, stain);
        }

		public override string toDataString()
		{
			return string.Format("{0},{1},{2}/", itemNumber, price, shippingPrice);
		}
    }

    /************************************************************
     *  The Box class is a subclass of the Item class.
     ************************************************************/
    public class JarOrganizer: Item{
        double width;
        int jarCount;
        public JarOrganizer(double price, double shippingPrice, Item.Item_Type type,
                Item.Stain_Color stain, double width, int count): base(price, shippingPrice, type, stain){
            this.width = width;
            this.jarCount = count;
            itemNumber = KrohndesignsStore.ItemNumberGenerator.getItemNumber(this);
        }

        public double getWidth(){
            return width;
        }

        public int getJarCount(){
            return jarCount;
        }

        public override string ToString(){
            string stain = base.getStainString();
            return string.Format("Mason Jar Organizer: {0}\t{1}\" Width, {2}", base.ToString(), width, stain);
        }

    }

    public class JarSconce: Item{
        double height;
        int numSconces;

        public JarSconce(double price, double shippingPrice, Item.Item_Type type,
                Item.Stain_Color stain, double height, int number): base(price, shippingPrice, type, stain){
            this.height = height;
            this.numSconces = number;
            itemNumber = KrohndesignsStore.ItemNumberGenerator.getItemNumber(this);
        }

        public double getHeight(){
            return height;
        }

        public int getSconceCount(){
            return numSconces;
        }

        public override string ToString(){
            string stain = base.getStainString();
            return string.Format("Mason Jar Sconces({0}): {1}\t{2}\" Height, {3}", numSconces, base.ToString(), height, stain);
        }
    }

    
}
