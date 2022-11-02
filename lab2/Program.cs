using System;

namespace escape 
{
    class Program 
    {
        static int GetInt(string s, int min, int max) 
        { 
            int result=min;
            bool valid=false;
            do 
            {
                Console.Write(s);
                valid=int.TryParse(Console.ReadLine(), out result);
            } while (!valid || result<min || result>max);

            return result;
        }
        static void Main(string[] args) 
        {
            //константы
            const int kitchen=1; 
            const int livingRoom=2; 
            const int study=3; //кабинет
            const int corridor=4;
            
            //переменные
            int loc=corridor;
            bool keyIsFound=false;
            bool doorIsOpen=false;
            bool windowIsOpen=false;
            bool getAlternative=false; //возможность выйти через дверь без ключа

            //ввод
            Console.WriteLine("Вы каким-то неведомым образом оказались заперты в заброшенном доме...");
            Console.WriteLine("Дом собираются снести, поэтому вам следует как можно скорее покинуть его!");
            Console.WriteLine("Действуйте!");
            Console.WriteLine();
            
            //основной цикл
            while(true) 
            {
                Console.WriteLine();
                if (loc==corridor) {
                    //описание и вывод вариантов действий
                    Console.WriteLine("Сейчас вы находитесь в коридоре.");
                    if (!doorIsOpen) { //дверь закрыта
                        Console.WriteLine("Вы видите запертую дверь, ее нужно открыть."); 
                    }  
                    Console.WriteLine("Ваши действия:");  
                    Console.WriteLine("1 - пойти на кухню.");
                    Console.WriteLine("2 - пойти в гостиную.");
                    Console.WriteLine("3 - пойти в кабинет.");
                    if (!doorIsOpen) {
                        Console.WriteLine("или 4 - открыть дверь.");
                    } else {
                        Console.WriteLine("или 4 - на свободу.");
                    }
                    //выбор действия
                    int choice=GetInt("Что сделаете?", 1, 4);
                    //обработка
                    if (choice==1) {   //уйти на кухню
                        loc=kitchen;
                    } else if (choice==2) { //уйти в гостиную
                        loc=livingRoom;
                    } else if (choice==3) { //уйти в кабинет
                        loc=study;
                    } else if (choice==4) { //открыть дверь или покинуть дом
                        if (doorIsOpen) {
                            //дверь открыта
                            break;
                        } else {
                            //дверь заперта
                            if (keyIsFound) {
                                doorIsOpen=true;
                                Console.WriteLine("Дверь открыта!");
                                }
                            else if (getAlternative) {
                                Console.WriteLine("У вас есть несколько вариантов действий:");
                                Console.WriteLine("1 - попытаться взломать замок на двери ножом.");
                                Console.WriteLine("2 - сломать дверь топором.");
                                Console.WriteLine("или 3 - снять дверь с петель при помощи отвертки.");
                                int choice_=GetInt("Что сделаете?", 1, 3);
                                if (choice_==1||choice_==2||choice_==3) {
                                    doorIsOpen=true;
                                    Console.WriteLine("Дверь открыта!");
                                }
                            } else {
                                Console.WriteLine("Чтобы открыть дверь, нужно найти ключ!");
                            }
                        }
                    }
                } else if (loc==kitchen) {
                    //описание и вывод вариантов действий
                    Console.WriteLine("Сейчас вы находитесь на кухне.");
                    Console.WriteLine("Повсюду разбросаны вещи: кухонная утварь(ножи,вилки,ложки,кастрюли), инструменты(топор,отвертки), которые кто-то принес из сарая, и мебель.");
                    Console.WriteLine("Возможно, здесь найдется что-то полезное.");
                    Console.WriteLine();
                    Console.WriteLine("Ваши действия:");
                    Console.WriteLine("1 - пойти в кабинет.");
                    Console.WriteLine("2 - пойти в гостиную.");
                    Console.WriteLine("3 - пойти в коридор.");
                    Console.WriteLine("4 - взять нож.");
                    Console.WriteLine("5 - взять топор/отвертку и попытаться выбраться без ключа.");
                    //выбор 
                    int choice=GetInt("Что сделаете?", 1, 5);
                    //обработка
                    if (choice==1) {
                        loc=study;
                    } else if (choice==2) {
                        loc=livingRoom;
                    } else if (choice==3) {
                        loc=corridor;
                    } else if (choice==4 || choice==5) {
                        if (!getAlternative) {
                            getAlternative=true;
                            loc=corridor;
                        }
                    }     
                } else if(loc==livingRoom) {
                    Console.WriteLine("Вы находитесь в гостиной.");
                    Console.WriteLine("Здесь довольно просторно, так как отсюда бывшие хозяева все-таки забрали мебель.");
                    Console.WriteLine("Вы видите единственное во всем доме незаколоченное окно.");
                    Console.WriteLine();
                    Console.WriteLine("Ваши действия:");
                    Console.WriteLine("1 - пойти на кухню.");
                    Console.WriteLine("2 - пойти в кабинет.");
                    Console.WriteLine("3 - пойти в коридор.");
                    if (!windowIsOpen) {
                        Console.WriteLine("или 4 - открыть окно.");
                    } else {
                        Console.WriteLine("или 4 - вылезти через окно.");
                    }
                    int choice=GetInt("Что сделаете?", 1, 4);
                    if (choice==1) {
                        loc=kitchen;
                    } else if (choice==2) {
                        loc=study;
                    } else if (choice==3) {
                        loc=corridor;
                    } else {
                        if (!windowIsOpen) {
                            windowIsOpen=true;
                            Console.WriteLine("Вы открыли окно.");
                        } else {
                            Console.WriteLine("Вы выбрались!");
                            break;
                        }
                    }
                } else if (loc==study) {
                    Console.WriteLine("Вы находитесь в кабинете.");
                    Console.WriteLine("Здесь очень пыльно, но вся обстановка практически сохранила свой первоначальный облик.");
                    Console.WriteLine("В кабинете есть все, что нужно для работы: кресло, стол с выдвижными ящиками, куча бумаг.");
                    Console.WriteLine();
                    Console.WriteLine("Ваши действия:");
                    Console.WriteLine("1 - пойти на кухню.");
                    Console.WriteLine("2 - пойти в гостиную.");
                    Console.WriteLine("3 - пойти в коридор.");
                    if (!keyIsFound) {
                        Console.WriteLine("или 4 - покопаться в ящиках стола.");
                    } else {
                        Console.WriteLine("или 4 - пойти открыть дверь.");
                    }
                    int choice=GetInt("Что сделаете?", 1, 4);
                    if (choice==1) {
                        loc=kitchen;
                    } else if(choice==2) {
                        loc=livingRoom;
                    } else if (choice==3) {
                        loc=corridor;
                    } else {
                        if (!keyIsFound) {
                            Console.WriteLine("В одном из ящиков вы нашли ключ. Возможно, именно от входной двери.");
                            keyIsFound=true;
                        } else {
                            loc=corridor;
                        }
                    }
                }
            }
        }
    }
}
