using static System.Console;

const int loc_kitchen=1; 
const int loc_livingRoom=2; 
const int loc_study=3; //кабинет
const int loc_corridor=4;
const int loc_table=5;
const int loc_door1=6;
const int loc_door2=7;
const int loc_exit=8;
const string intro="Вы каким-то неведомым образом оказались заперты в заброшенном доме... Дом собираются снести, поэтому вам следует как можно скорее покинуть его! Действуйте!";
const string final="Вы выбрались!";
string [] LocDescr=new string []
{
    "Сейчас вы находитесь в коридоре.",
    "Сейчас вы находитесь на кухне. Повсюду разбросаны вещи: кухонная утварь, инструменты, которые кто-то принес из сарая, и мебель.",
    "Вы находитесь в гостиной. Здесь довольно просторно, так как отсюда бывшие хозяева все-таки забрали мебель. Вы видите единственное во всем доме незаколоченное окно.",
    "Вы находитесь в кабинете. Здесь очень пыльно, но вся обстановка практически сохранила свой первоначальный облик. В кабинете есть все, что нужно для работы: кресло, стол с выдвижными ящиками, куча бумаг.",
    "В столе - ключ от входной двери",
    "Перед вами - закрытая на замок дверь. Вы не можете открыть ее, так как нет ключа",
    "Перед вами - закрытая на замок дверь. Вы можете открыть ее, так как ключ вы нашли",
    "На свободу!"
};
string [] toDo=new string []
{
    "Уйти на кухню", "Уйти в коридор", "Уйти в кабинет", "Уйти в гостиную", 
    "Покопаться в ящике стола", "Взять ключ и уйти к двери", 
    "Открыть дверь ключом и выбраться из дома", 
    "Открыть окно и вылезти через него", 
    "Подойти к двери", "Отойти от двери", 
};
Story story=new StoryBuilder()
    .SetupStory(intro, final, loc_corridor)
    .AddLocation(loc_corridor, LocDescr[0])
    .AddLocation(loc_kitchen, LocDescr[1])
    .AddLocation(loc_livingRoom, LocDescr[2])
    .AddLocation(loc_study, LocDescr[3])
    .AddLocation(loc_table, LocDescr[4])
    .AddLocation(loc_door1, LocDescr[5])
    .AddLocation(loc_door2, LocDescr[6])
    .AddLocation(loc_exit, LocDescr[7])
    ////////////////////////////////////
    .AddOption(loc_corridor, loc_kitchen, toDo[0])
    .AddOption(loc_corridor, loc_study, toDo[2])
    .AddOption(loc_corridor, loc_livingRoom, toDo[3])
    .AddOption(loc_corridor, loc_door1, toDo[8])
    ////////////////////////////////////
    .AddOption(loc_kitchen, loc_corridor, toDo[1])
    .AddOption(loc_kitchen, loc_study, toDo[2])
    .AddOption(loc_kitchen, loc_livingRoom, toDo[3])
    ///////////////////////////////////
    .AddOption(loc_livingRoom, loc_corridor, toDo[1])
    .AddOption(loc_livingRoom, loc_study, toDo[2])
    .AddOption(loc_livingRoom, loc_kitchen, toDo[0])
    .AddOption(loc_livingRoom, loc_exit, toDo[7])
    ///////////////////////////////////
    .AddOption(loc_study, loc_corridor, toDo[1])
    .AddOption(loc_study, loc_livingRoom, toDo[3])
    .AddOption(loc_study, loc_kitchen, toDo[0])
    .AddOption(loc_study, loc_table, toDo[4])
    .AddOption(loc_table, loc_door2, toDo[5])
    //////////////////////////////////
    .AddOption(loc_door1, loc_corridor, toDo[9])
    .AddOption(loc_door2, loc_exit, toDo[6])
    .Build();
//////////////
////engine////
//////////////
Clear();
WriteLine(story.Intro);
while(true) {
    Location loc=story.Locations.First(item=>item.Id==story.CurrentLocationId);
    WriteLine();
    WriteLine(loc.Description);
    for (int i=0; i<loc.Options.Count; i++) {
        WriteLine($"{i+1}. {loc.Options[i].Title}");
        if (story.CurrentLocationId==loc_exit) goto Found;
    }
    for (int i=0; i==loc.Options.Count; i++) {
        if (i==loc.Options.Count)
            goto Found;
    }        
    int n=GetInt("Ваш выбор:", 1, loc.Options.Count)-1;
    loc.Options[n].Work!();
}
Found: WriteLine(story.Final);
int GetInt(string s, int min, int max) {
    int result=min;
    bool valid=false;
    do {
        Write(s);
        valid=int.TryParse(ReadLine(), out result);
    } while (!valid || result<min || result>max);
    return result;
}

