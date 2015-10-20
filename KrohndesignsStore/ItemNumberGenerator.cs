using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * The ItemNumberGenerator class is used to generate an item number that identifies a specific Item that is for sale.
 * The item number is generated based on the Item_Type and the attributes of each item type. It's also used to parse
 * item numbers to create Item objects.
 * For example, an item number of 110022436 is based on the following:
 * 1 - Chalkboard
 * 1 - Dark Red Stain 
 * 0 - Magnetic 
 * 0 - Mitered
 * 2 - Both Hanging Directions
 * 2 - First digit of 24 inch length
 * 4 - Second digit of 24 inch length
 * 3 - First digit of 36 inch width
 * 6 - Second digit of 36 inch width
 */
namespace KrohndesignsStore
{
    class ItemNumberGenerator {

        // Generates an item number based on the attributes of an Item object.
        public static int getItemNumber(ShoppingCart.Item item){
            int itemNumber = (int)item.getType() + 1;
            itemNumber = (itemNumber * 10) + (int)item.getStain();

            // Based on the type of the item, generate additional digits for the item number based on that Item_Types attributes.
            if(item.getType() == ShoppingCart.Item.Item_Type.Board){
                itemNumber = (itemNumber * 10) + (int)((ShoppingCart.Chalkboard)item).getMagneticType();
                itemNumber = (itemNumber * 10) + (int)((ShoppingCart.Chalkboard)item).getFrameStyle();
                itemNumber = (itemNumber * 10) + (int)((ShoppingCart.Chalkboard)item).getHangingDirection();
                itemNumber = (itemNumber * 100) + (int)((ShoppingCart.Chalkboard)item).getLength();
                itemNumber = (itemNumber * 100) + (int)((ShoppingCart.Chalkboard)item).getWidth();
            }
            else if(item.getType() == ShoppingCart.Item.Item_Type.Sconce){
                // Item number multiplied by 10000000 to match length of chalkboard item number.
                itemNumber = (itemNumber * 10000000) + (int)((ShoppingCart.Sconce)item).getHeight();
            }
            else if(item.getType() == ShoppingCart.Item.Item_Type.Box){
                // Item number multiplied by 10000000 to match length of chalkboard item number.
                itemNumber = (itemNumber * 10000000) + (int)((ShoppingCart.Box)item).getLength();
            }
            else if(item.getType() == ShoppingCart.Item.Item_Type.Organizer){
                // Item number multiplied by 10000000 to match length of chalkboard item number.
                itemNumber = (itemNumber * 10) + (int)((ShoppingCart.JarOrganizer)item).getJarCount();
                itemNumber = (itemNumber * 1000000) + (int)((ShoppingCart.JarOrganizer)item).getWidth();
            }
            else if(item.getType() == ShoppingCart.Item.Item_Type.JarSconce){
                // Item number multiplied by 10000000 to match length of chalkboard item number.
                itemNumber = (itemNumber * 10) + (int)((ShoppingCart.JarSconce)item).getSconceCount();
                itemNumber = (itemNumber * 1000000) + (int)((ShoppingCart.JarSconce)item).getHeight();
            }
            return itemNumber;
        }
    
        // Return an Item object that's created from an itemNumber.
        public static ShoppingCart.Item getItemFromNumber(int itemNumber){
            string numberString = itemNumber.ToString();
                switch(numberString[0]){
                    case '1': return parseChalkboardNumber(numberString);
                    case '2': return parseBoxNumber(numberString);
                    case '3': return parseSconceNumber(numberString);
                    case '4':
                    case '5':
                    case '6':
                    default:
                        Console.WriteLine(numberString[0]);
                        throw new Exception("Invalid format for item number. (getItemNumber(int itemNumber)");
                }
        }

		private static ShoppingCart.Box parseBoxNumber(string itemNumber){
			ShoppingCart.Item.Item_Type type = ShoppingCart.Item.Item_Type.Box;
			ShoppingCart.Item.Stain_Color stain = getStainColor((int)Char.GetNumericValue(itemNumber[1]));
			double length = Convert.ToDouble(itemNumber.Substring(7, 2));
			return new ShoppingCart.Box(0, 0, type, stain, length);
		}

		private static ShoppingCart.Sconce parseSconceNumber(string itemNumber){
			ShoppingCart.Item.Item_Type type = ShoppingCart.Item.Item_Type.Sconce;
			ShoppingCart.Item.Stain_Color stain = getStainColor((int)Char.GetNumericValue(itemNumber[1]));
			double height = Convert.ToDouble(itemNumber.Substring(7,2));
			return new ShoppingCart.Sconce(0, 0, type, stain, height);
		}

        // Creates a chalkboard object based on an item number.
        private static ShoppingCart.Chalkboard parseChalkboardNumber(string itemNumber){
            ShoppingCart.Item.Item_Type type = ShoppingCart.Item.Item_Type.Board;
            ShoppingCart.Item.Stain_Color stain = getStainColor((int)Char.GetNumericValue(itemNumber[1]));
            ShoppingCart.Chalkboard.Magnetic_Type mag = getMagneticType((int)Char.GetNumericValue(itemNumber[2]));
            ShoppingCart.Chalkboard.Frame_Style frame = getFrameStyle((int)Char.GetNumericValue(itemNumber[3]));
            ShoppingCart.Chalkboard.Hanging_Direction hang = getHangingDirection((int)Char.GetNumericValue(itemNumber[4]));
            double length = Convert.ToDouble(itemNumber.Substring(5, 2));
            double width = Convert.ToDouble(itemNumber.Substring(7, 2));
            return new ShoppingCart.Chalkboard(0, 0, type, stain, length, width, mag, frame, hang);
        }

        // returns a Stain_Color based on an item number.
        private static ShoppingCart.Item.Stain_Color getStainColor(int number){
            switch(number){
                case 0: return ShoppingCart.Item.Stain_Color.Red;
                case 1: return ShoppingCart.Item.Stain_Color.DarkRed;
                case 2: return ShoppingCart.Item.Stain_Color.Gray;
                case 3: return ShoppingCart.Item.Stain_Color.Walnut;
                case 4: return ShoppingCart.Item.Stain_Color.Ebony;
                case 5: return ShoppingCart.Item.Stain_Color.White;
                default: 
                    Console.WriteLine(number);
                    throw new Exception("Invalid number for stain color");
            }
        }

        // returns a Frame_Style based on an item number.
        private static ShoppingCart.Chalkboard.Frame_Style getFrameStyle(int number){
            switch(number){
                case 0: return ShoppingCart.Chalkboard.Frame_Style.Mitered;
                case 1: return ShoppingCart.Chalkboard.Frame_Style.Straight;
                default: throw new Exception("Invalid number for frame style.");
            }
        }

        // returns a Hanging_Direction based on an item number.
        private static ShoppingCart.Chalkboard.Hanging_Direction getHangingDirection(int number){
            switch(number){
                case 0: return ShoppingCart.Chalkboard.Hanging_Direction.Horizontal;
                case 1: return ShoppingCart.Chalkboard.Hanging_Direction.Vertical;
                case 2: return ShoppingCart.Chalkboard.Hanging_Direction.Both;
                default: throw new Exception("Invalid number for hanging direction.");
            }
        }

        // returns a Magnetic_Type based on an item number.
        private static ShoppingCart.Chalkboard.Magnetic_Type getMagneticType(int number){
            switch(number){
                case 0: return ShoppingCart.Chalkboard.Magnetic_Type.Magnetic;
                case 1: return ShoppingCart.Chalkboard.Magnetic_Type.NonMagnetic;
                default: throw new Exception("Invalid number for magnetic type.");
            }
        }

    }
}
