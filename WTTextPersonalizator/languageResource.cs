using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WTTextPersonalizator
{
    public class languageResource
    {
        public string language = "";
        //mainWindow
        public string chooseFolderButton = "";
        public string remeberCheck = "";
        public string launchButton = "";
        public string cantFindFolder = "";
        public string messageAddToConfig = "";
        public string nowRGame = "";
        public string justRGame = "";
        //workingframe
        //comboItems
        public string toBattle = "";
        public string enemyDestroyed = "";
        public string planeDestroyed = "";
        public string asist = "";
        public string hit = "";
        public string captureZone = "";
        public string kaboom = "";
        public string noPen = "";
        public string ricoshet = "";
        public string noDamage = "";
        public string crewDestroyed = "";
        public string critDamage = "";
        public string critDmg = "";
        public string scout = "";
        public string scoutDamage = "";
        public string scoutDestroyed = "";
        public string returnToHangar = "";
        public string missionWin = "";
        public string missionLost = "";
        public string repair = "";
        public string fire = "";
        public string lostControl = "";
        public string overload = "";
        //labels
        public string changeMenu = "";
        public string frequentOptions = "";
        public string initValue = "";
        public string endValue = "";
        public string changeUi = "";
        public string saveConfig = "";
        public string notSaveConfig = "";
        //buttons
        public string patchBtn = "";
        public string changeBtn = "";
        public string clearBtn = "";
        public string savingConfigBtn = "";
        public string loadConfigBtn = "";
        public string instalConfigBtn = "";
        public string instructionBtn = "";
        //messageboxes
        public string changesSucces;
        public string notFound;
        public string stopSavingConfig;
        public string saveToAnotherDir;
        public string cannotSaveInGameDir;

        //instuction
        public string instructionMain;
        public string first;
        public string firstadd;
        public string second;
        public string secondAdd;
        public string third;
        public string fourth;
        public string fifth;
        public string fifthAdd;
        public string sixth;
        public string sixthdotone;
        public string closeInstr;

        //instasavedconfig
        public string errorLoading;
        public string successLoading;

        //misc
        public string checkRunning;
        public languageResource(string lang) 
        {
            language= lang;
            if(lang=="ru")
            {
                //main
                chooseFolderButton = "Выбрать папку с игрой";
                remeberCheck = "Запомнить";
                launchButton = "Запустить";
                cantFindFolder = "Укажите корректный путь игры";
                messageAddToConfig = "Путь указан корректно, но папка /lang отутсвует. Чтобы она появилась необходимо внести изменения в файл config.blk, а после запустить игру, выполнить?";
                justRGame = "Ой! Изменения в файл уже были внесены, но папки /lang нету. Похоже, что надо просто запустить игру, дождаться прогрузки ангара и выйти из нее";
                nowRGame = "Отлично! Изменения внесены успешно. Теперь просто запустите игру, дождитесь прогрузки ангара и выйдите из нее";
                //workingframe
                //comboitems
                //menu.csv
                toBattle =          "В бой!                                         ";
                enemyDestroyed =    "Техника уничтожена                             ";
                planeDestroyed =    "Самолёт сбит                                   ";
                asist =             "Помощь в уничтожении противника                ";
                hit =               "Попадание                                      ";
                captureZone =       "Зона захвачена                                 ";
                kaboom =            "Взрыв боекомплекта                             ";
                noPen =             "Не пробил                                      ";
                ricoshet =          "Рикошет                                        ";
                noDamage =          "Цель не была повреждена                        ";
                crewDestroyed =     "Экипаж выведен из строя                        ";
                critDamage =        "Критический урон                               ";
                critDmg =           "Критические повреждения                        ";
                scout =             "Цель разведана                                 ";
                scoutDamage =       "Разведанная цель получила урон                 ";
                scoutDestroyed =    "Разведанная цель уничтожена (по разведданным)  ";
                returnToHangar =    "Вернуться в ангар                              ";
                //ui.csv
                missionWin =        "Миссия выполнена                               ";
                missionLost =       "Миссия провалена                               ";
                repair =            "удерживайте, чтобы начать ремонт танка         ";
                fire =              "Начать тушить пожар                            ";
                //airthings
                lostControl =       "ПОТЕРЯ УПРАВЛЕНИЯ                              ";
                overload =          "ПЕРЕГРУЗКА                                     ";
                //labels
                changeMenu = "Изменения в файле menu.csv (В бой, Техника уничтожена, Попадание и т.д.)";
                frequentOptions = "Частые варианты";
                initValue = "Начальное значение";
                endValue = "Конечное значение";
                changeUi = "Изменения в файле ui.csv (Миссия выполнена, Миссия провалена, Начать тушить пожар)";
                saveConfig = "Сохраняется";
                notSaveConfig = "Не сохраняется";
                //buttons
                patchBtn = "Вышел патч";
                changeBtn = "Поменять";
                clearBtn = "Очистить";
                savingConfigBtn = "Сохранять конфиг";
                loadConfigBtn = "Открыть конфиг";
                instalConfigBtn = "Установить";
                instructionBtn = "Инструкция";
                //messageBoxes
                changesSucces = "Изменено успешно";
                notFound = "Такое же значение уже записано или не найдено";
                stopSavingConfig = "Вы уверены, что хотите отключить сохранение конфигурации?\nВ таком случае для обновления надписей вам \nпридется указать текущее значение!";
                saveToAnotherDir = "Сохраните файл в другую папку, отличную от корневой директивы игры";
                cannotSaveInGameDir = "Нельзя сохранить конфигурацию в эту папку";
                //instruction
                instructionMain = "Инструкция";
                first = "1. Укажите путь к игре. Либо нажав на кнопку, либо указав путь вручную (пример на изображении)";
                firstadd = "При нажатии Запомнить, путь к игре будет сохранен";
                second = "2. В главном окне вам предстоит указать надпись которую вы хотите заменить и надпись на которую будет произведена замена";
                secondAdd = "Вы можете выбрать частые варианты из соответствующего меню";
                third = "3. Если активировано сохранение конфига, то если вы захотите изменить свои подписи, то вам не придется указывать их, просто укажите изначальное значение и то на которое вы хотите его заменить";
                fourth = "4. Нажав на кнопку Загрузить конфиг, включится отображение выбранного конфига. Используя эту функцию вы можете повторить свои изменения после патча";
                fifth = "5. После выхода патча необходимо: Нажать на кнопку Вышел патч, сохранить текущий конфиг в любое место, кроме основной директории игры;" +
                    " запустить игру и дождаться прогрузки, выйти из игры; выполнить П.4; произвести изменения по-новой";
                fifthAdd = "КРАЙНЕ РЕКОМЕНДУЕТСЯ ЗАКРЫВАТЬ ПРИЛОЖЕНИЕ ВО ВРЕМЯ ЗАГРУЗКИ И РАБОТЫ САМОЙ ИГРЫ ВО ИЗБЕЖАНИИ ПРОБЛЕМ";
                sixth = "6. После выхода патча можно загрузить предыдущую конфигурацию. Выполните П.4 и выберете конфиг, созданный в П.5, после чего нажмите Установить. После этого старый конфиг будет установлен";
                sixthdotone = "6.1. Чтобы установить конфиг в любое другое время, выполните последовательно П.5 и П.6";
                closeInstr = "Закрыть";
                //instasavedconfig
                errorLoading = "Текущий конфиг содержит значения, прежде чем загружать старый конфиг, пожалуйста сбросьте текущий через Вышел патч";
                successLoading= "Конфиг успешно загружен";
                //misc
                checkRunning = "Игра запущенна в данный момент. Пожалуйста закройте приложение и перезапустите его после выхода из игры!";
            }
            else
            {
                //main
                chooseFolderButton = "Choose game folder";
                remeberCheck = "Remember";
                launchButton = "Launch";
                cantFindFolder = "Specify the correct path of the game";
                messageAddToConfig = "The path is specified correctly, but the /lang folder is missing. In order for it to appear, you need to make changes to the config.blk file, and then launch the game, do it?";
                justRGame = "Oh! Changes have already been made to the file, but there is no /lang folder. It seems that you just need to start the game, wait for the hangar to load and exit it";
                nowRGame = "Great! The changes were made successfully. Now just start the game, wait for the hangar to load and exit it";
                //workingframe
                //comboitems
                //menu.csv
                toBattle =          "To Battle!                                 ";
                enemyDestroyed =    "Target destroyed                           ";
                planeDestroyed =    "Aircraft destroyed                         ";
                asist =             "Enemy Kill Assist                          ";
                hit =               "Hit                                        ";
                captureZone =       "Zone captured                              ";
                kaboom =            "Ammunition exploded                        ";
                noPen =             "Non-penetration                            ";
                ricoshet =          "Ricochet                                   ";
                noDamage =          "Target undamaged                           ";
                crewDestroyed =     "Crew knocked out                           ";
                critDamage =        "Critical Hit                               ";
                critDmg =           "Critical hit                               ";
                scout =             "Target scouted                             ";
                scoutDamage =       "Scouted target damaged                     ";
                scoutDestroyed =    "Scouted target destroyed (by intelligence) ";
                returnToHangar =    "Return to the Hangar                       ";
                //ui.csv
                missionWin =        "Mission Accomplished                       ";
                missionLost =       "Mission Failed                             ";
                repair =            "hold to start repairing the ground vehicle ";
                fire =              "Activate extinguisher                      ";
                //air things
                lostControl =       "LOST CONTROL                               ";
                overload =          "OVERLOAD                                   ";
                //labels
                changeMenu = "Changes in menu.csv file";
                frequentOptions = "Frequent Options";
                initValue = "Initial value";
                endValue = "End Value";
                changeUi = "Changes in ui.csv file";
                saveConfig = "Saving";
                notSaveConfig = "Not saving";
                //buttons
                patchBtn = "Patch comeout";
                changeBtn = "Change";
                clearBtn = "Clear";
                savingConfigBtn = "Saving config";
                loadConfigBtn = "Load config";
                instalConfigBtn = "Install";
                instructionBtn = "Instruction";
                //messageBoxes
                changesSucces = "Changed Successfully";
                notFound = "The same value has already been written or not found";
                stopSavingConfig = "Are you sure you want to disable config saving?\nIn this case, to update the labels,\nyou need to specify the current value!";
                saveToAnotherDir = "Save the file to a different folder than the root directive of the game";
                cannotSaveInGameDir = "You cannot save the configuration to this folder";
                //instruction
                instructionMain = "Instruction";
                first = "1. Specify the path to the game. Either by clicking on the button, or by specifying the path manually (example in the image)";
                firstadd = "When you click Remember, the path to the game will be saved";
                second = "2. In the main window you have to specify the label that you want to replace and the label that will be replaced";
                secondAdd = "You can select frequent options from the corresponding menu";
                third = "3. If saving the config is activated, then if you want to change your labels, then you do not have to specify them, just specify the original value and the one you want to replace it with";
                fourth = "4. By clicking on the Load config button, the display of the selected config will turn on. Using this feature you can repeat your changes after the patch";
                fifth = "5. After the patch is released, you must: Click on the Patch button, save the current config to any place except the main directory of the game; " +
                    "start the game and wait for the load, exit the game; perform Step 4; make changes in a new way";
                fifthAdd = "IT IS HIGHLY RECOMMENDED TO CLOSE THE APPLICATION WHILE LOADING AND RUNNING THE GAME ITSELF IN ORDER TO AVOID PROBLEMS";
                sixth = "6. After the patch is released, you can install the previous configuration. Follow Step 4 and select the config created in Step 5, then click Install. After that, the old config will be installed";
                sixthdotone = "6.1. To install the config at any other time, follow Step 5 and Step 6 sequentially";
                closeInstr = "Close";
                //instasavedconfig
                errorLoading = "The current config contains the values, before downloading the old config, please reset the current one through the released patch";
                successLoading = "Config loaded successfully";
                //misc
                checkRunning = "The game is currently running. Please close the app and restart it after exiting the game!";
            }
        }
    }
}
