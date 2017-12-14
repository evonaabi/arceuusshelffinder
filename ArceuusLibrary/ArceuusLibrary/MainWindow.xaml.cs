using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArceuusLibrary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int books                 = 26;                   //Number of books (and manuscripts total)
        const int manuscripts           = 10;                   //Number of manuscripts
        const int jumpDistance          = 356 / books;          //Amount of non-dead shelves between possible shelves
        Button[] shelves                = new Button[547];      //All shelves
        List<TextBlock> labels          = new List<TextBlock>();//List of labels (TextBlocks) added to the grid marking the books
        int firstShelf                  = -1;                   //Index of the first shelf that is found
        bool initialClick               = true;                 //Boolean to tell if next shelf is the first shelf
        int[] possibleShelvesForwards   = new int[books-1];     //Array of possible shelf locations going forwards (clockwise)
        int[] possibleShelvesBackwards  = new int[books-1];     //Array of possible shelf locations going backwards (counter-clockwise)
        int[,] foundBooksByRoom         = new int[11, 4];       //2D array of books found sorted by room
        Style basicShelf                = null;                 //Style for a basic shelf
        Style confirmedShelf            = null;                 //Style for a confirmed shelf
        Style possibleShelfForwards     = null;                 //Style for a possible shelf when rotating forwards (clockwise)
        Style possibleShelfBackwards    = null;                 //Style for a possible shelf when rotating backwards (counter-clockwise)
        public static int newestBook    = -1;                   //Number of the newest book found, assigned from the Book prompt
        
        /*
         * Gets shelf index, returns room index
         */
        private int GetRoomForShelf(int shelf)
        {
            if (shelf < 50)
                return 0;
            else if (shelf < 99)
                return 1;
            else if (shelf < 148)
                return 2;
            else if (shelf < 202)
                return 3;
            else if (shelf < 259)
                return 4;
            else if (shelf < 292)
                return 5;
            else if (shelf < 334)
                return 6;
            else if (shelf < 403)
                return 7;
            else if (shelf < 461)
                return 8;
            else if (shelf < 519)
                return 9;
            else 
                return 10;

        }

        /*
         * Function to add all of the shelves to a single array
         * Also adds event listeners for clicking
         */
        private void InitializeShelves()
        {
            shelves[0] = shelf1;
            shelves[1] = shelf2;
            shelves[2] = shelf3;
            shelves[3] = shelf4;
            shelves[4] = shelf5;
            shelves[5] = shelf6;
            shelves[6] = shelf7;
            shelves[7] = shelf8;
            shelves[8] = shelf9;
            shelves[9] = shelf10;
            shelves[10] = shelf11;
            shelves[11] = shelf12;
            shelves[12] = shelf13;
            shelves[13] = shelf14;
            shelves[14] = shelf15;
            shelves[15] = shelf16;
            shelves[16] = shelf17;
            shelves[17] = shelf18;
            shelves[18] = shelf19;
            shelves[19] = shelf20;
            shelves[20] = shelf21;
            shelves[21] = shelf22;
            shelves[22] = shelf23;
            shelves[23] = shelf24;
            shelves[24] = shelf25;
            shelves[25] = shelf26;
            shelves[26] = shelf27;
            shelves[27] = shelf28;
            shelves[28] = shelf29;
            shelves[29] = shelf30;
            shelves[30] = shelf31;
            shelves[31] = shelf32;
            shelves[32] = shelf33;
            shelves[33] = shelf34;
            shelves[34] = shelf35;
            shelves[35] = shelf36;
            shelves[36] = shelf37;
            shelves[37] = shelf38;
            shelves[38] = shelf39;
            shelves[39] = shelf40;
            shelves[40] = shelf41;
            shelves[41] = shelf42;
            shelves[42] = shelf43;
            shelves[43] = shelf44;
            shelves[44] = shelf45;
            shelves[45] = shelf46;
            shelves[46] = shelf47;
            shelves[47] = shelf48;
            shelves[48] = shelf49;
            shelves[49] = shelf50;
            shelves[50] = shelf51;
            shelves[51] = shelf52;
            shelves[52] = shelf53;
            shelves[53] = shelf54;
            shelves[54] = shelf55;
            shelves[55] = shelf56;
            shelves[56] = shelf57;
            shelves[57] = shelf58;
            shelves[58] = shelf59;
            shelves[59] = shelf60;
            shelves[60] = shelf61;
            shelves[61] = shelf62;
            shelves[62] = shelf63;
            shelves[63] = shelf64;
            shelves[64] = shelf65;
            shelves[65] = shelf66;
            shelves[66] = shelf67;
            shelves[67] = shelf68;
            shelves[68] = shelf69;
            shelves[69] = shelf70;
            shelves[70] = shelf71;
            shelves[71] = shelf72;
            shelves[72] = shelf73;
            shelves[73] = shelf74;
            shelves[74] = shelf75;
            shelves[75] = shelf76;
            shelves[76] = shelf77;
            shelves[77] = shelf78;
            shelves[78] = shelf79;
            shelves[79] = shelf80;
            shelves[80] = shelf81;
            shelves[81] = shelf82;
            shelves[82] = shelf83;
            shelves[83] = shelf84;
            shelves[84] = shelf85;
            shelves[85] = shelf86;
            shelves[86] = shelf87;
            shelves[87] = shelf88;
            shelves[88] = shelf89;
            shelves[89] = shelf90;
            shelves[90] = shelf91;
            shelves[91] = shelf92;
            shelves[92] = shelf93;
            shelves[93] = shelf94;
            shelves[94] = shelf95;
            shelves[95] = shelf96;
            shelves[96] = shelf97;
            shelves[97] = shelf98;
            shelves[98] = shelf99;
            shelves[99] = shelf100;
            shelves[100] = shelf101;
            shelves[101] = shelf102;
            shelves[102] = shelf103;
            shelves[103] = shelf104;
            shelves[104] = shelf105;
            shelves[105] = shelf106;
            shelves[106] = shelf107;
            shelves[107] = shelf108;
            shelves[108] = shelf109;
            shelves[109] = shelf110;
            shelves[110] = shelf111;
            shelves[111] = shelf112;
            shelves[112] = shelf113;
            shelves[113] = shelf114;
            shelves[114] = shelf115;
            shelves[115] = shelf116;
            shelves[116] = shelf117;
            shelves[117] = shelf118;
            shelves[118] = shelf119;
            shelves[119] = shelf120;
            shelves[120] = shelf121;
            shelves[121] = shelf122;
            shelves[122] = shelf123;
            shelves[123] = shelf124;
            shelves[124] = shelf125;
            shelves[125] = shelf126;
            shelves[126] = shelf127;
            shelves[127] = shelf128;
            shelves[128] = shelf129;
            shelves[129] = shelf130;
            shelves[130] = shelf131;
            shelves[131] = shelf132;
            shelves[132] = shelf133;
            shelves[133] = shelf134;
            shelves[134] = shelf135;
            shelves[135] = shelf136;
            shelves[136] = shelf137;
            shelves[137] = shelf138;
            shelves[138] = shelf139;
            shelves[139] = shelf140;
            shelves[140] = shelf141;
            shelves[141] = shelf142;
            shelves[142] = shelf143;
            shelves[143] = shelf144;
            shelves[144] = shelf145;
            shelves[145] = shelf146;
            shelves[146] = shelf147;
            shelves[147] = shelf148;
            shelves[148] = shelf149;
            shelves[149] = shelf150;
            shelves[150] = shelf151;
            shelves[151] = shelf152;
            shelves[152] = shelf153;
            shelves[153] = shelf154;
            shelves[154] = shelf155;
            shelves[155] = shelf156;
            shelves[156] = shelf157;
            shelves[157] = shelf158;
            shelves[158] = shelf159;
            shelves[159] = shelf160;
            shelves[160] = shelf161;
            shelves[161] = shelf162;
            shelves[162] = shelf163;
            shelves[163] = shelf164;
            shelves[164] = shelf165;
            shelves[165] = shelf166;
            shelves[166] = shelf167;
            shelves[167] = shelf168;
            shelves[168] = shelf169;
            shelves[169] = shelf170;
            shelves[170] = shelf171;
            shelves[171] = shelf172;
            shelves[172] = shelf173;
            shelves[173] = shelf174;
            shelves[174] = shelf175;
            shelves[175] = shelf176;
            shelves[176] = shelf177;
            shelves[177] = shelf178;
            shelves[178] = shelf179;
            shelves[179] = shelf180;
            shelves[180] = shelf181;
            shelves[181] = shelf182;
            shelves[182] = shelf183;
            shelves[183] = shelf184;
            shelves[184] = shelf185;
            shelves[185] = shelf186;
            shelves[186] = shelf187;
            shelves[187] = shelf188;
            shelves[188] = shelf189;
            shelves[189] = shelf190;
            shelves[190] = shelf191;
            shelves[191] = shelf192;
            shelves[192] = shelf193;
            shelves[193] = shelf194;
            shelves[194] = shelf195;
            shelves[195] = shelf196;
            shelves[196] = shelf197;
            shelves[197] = shelf198;
            shelves[198] = shelf199;
            shelves[199] = shelf200;
            shelves[200] = shelf201;
            shelves[201] = shelf202;
            shelves[202] = shelf203;
            shelves[203] = shelf204;
            shelves[204] = shelf205;
            shelves[205] = shelf206;
            shelves[206] = shelf207;
            shelves[207] = shelf208;
            shelves[208] = shelf209;
            shelves[209] = shelf210;
            shelves[210] = shelf211;
            shelves[211] = shelf212;
            shelves[212] = shelf213;
            shelves[213] = shelf214;
            shelves[214] = shelf215;
            shelves[215] = shelf216;
            shelves[216] = shelf217;
            shelves[217] = shelf218;
            shelves[218] = shelf219;
            shelves[219] = shelf220;
            shelves[220] = shelf221;
            shelves[221] = shelf222;
            shelves[222] = shelf223;
            shelves[223] = shelf224;
            shelves[224] = shelf225;
            shelves[225] = shelf226;
            shelves[226] = shelf227;
            shelves[227] = shelf228;
            shelves[228] = shelf229;
            shelves[229] = shelf230;
            shelves[230] = shelf231;
            shelves[231] = shelf232;
            shelves[232] = shelf233;
            shelves[233] = shelf234;
            shelves[234] = shelf235;
            shelves[235] = shelf236;
            shelves[236] = shelf237;
            shelves[237] = shelf238;
            shelves[238] = shelf239;
            shelves[239] = shelf240;
            shelves[240] = shelf241;
            shelves[241] = shelf242;
            shelves[242] = shelf243;
            shelves[243] = shelf244;
            shelves[244] = shelf245;
            shelves[245] = shelf246;
            shelves[246] = shelf247;
            shelves[247] = shelf248;
            shelves[248] = shelf249;
            shelves[249] = shelf250;
            shelves[250] = shelf251;
            shelves[251] = shelf252;
            shelves[252] = shelf253;
            shelves[253] = shelf254;
            shelves[254] = shelf255;
            shelves[255] = shelf256;
            shelves[256] = shelf257;
            shelves[257] = shelf258;
            shelves[258] = shelf259;
            shelves[259] = shelf260;
            shelves[260] = shelf261;
            shelves[261] = shelf262;
            shelves[262] = shelf263;
            shelves[263] = shelf264;
            shelves[264] = shelf265;
            shelves[265] = shelf266;
            shelves[266] = shelf267;
            shelves[267] = shelf268;
            shelves[268] = shelf269;
            shelves[269] = shelf270;
            shelves[270] = shelf271;
            shelves[271] = shelf272;
            shelves[272] = shelf273;
            shelves[273] = shelf274;
            shelves[274] = shelf275;
            shelves[275] = shelf276;
            shelves[276] = shelf277;
            shelves[277] = shelf278;
            shelves[278] = shelf279;
            shelves[279] = shelf280;
            shelves[280] = shelf281;
            shelves[281] = shelf282;
            shelves[282] = shelf283;
            shelves[283] = shelf284;
            shelves[284] = shelf285;
            shelves[285] = shelf286;
            shelves[286] = shelf287;
            shelves[287] = shelf288;
            shelves[288] = shelf289;
            shelves[289] = shelf290;
            shelves[290] = shelf291;
            shelves[291] = shelf292;
            shelves[292] = shelf293;
            shelves[293] = shelf294;
            shelves[294] = shelf295;
            shelves[295] = shelf296;
            shelves[296] = shelf297;
            shelves[297] = shelf298;
            shelves[298] = shelf299;
            shelves[299] = shelf300;
            shelves[300] = shelf301;
            shelves[301] = shelf302;
            shelves[302] = shelf303;
            shelves[303] = shelf304;
            shelves[304] = shelf305;
            shelves[305] = shelf306;
            shelves[306] = shelf307;
            shelves[307] = shelf308;
            shelves[308] = shelf309;
            shelves[309] = shelf310;
            shelves[310] = shelf311;
            shelves[311] = shelf312;
            shelves[312] = shelf313;
            shelves[313] = shelf314;
            shelves[314] = shelf315;
            shelves[315] = shelf316;
            shelves[316] = shelf317;
            shelves[317] = shelf318;
            shelves[318] = shelf319;
            shelves[319] = shelf320;
            shelves[320] = shelf321;
            shelves[321] = shelf322;
            shelves[322] = shelf323;
            shelves[323] = shelf324;
            shelves[324] = shelf325;
            shelves[325] = shelf326;
            shelves[326] = shelf327;
            shelves[327] = shelf328;
            shelves[328] = shelf329;
            shelves[329] = shelf330;
            shelves[330] = shelf331;
            shelves[331] = shelf332;
            shelves[332] = shelf333;
            shelves[333] = shelf334;
            shelves[334] = shelf335;
            shelves[335] = shelf336;
            shelves[336] = shelf337;
            shelves[337] = shelf338;
            shelves[338] = shelf339;
            shelves[339] = shelf340;
            shelves[340] = shelf341;
            shelves[341] = shelf342;
            shelves[342] = shelf343;
            shelves[343] = shelf344;
            shelves[344] = shelf345;
            shelves[345] = shelf346;
            shelves[346] = shelf347;
            shelves[347] = shelf348;
            shelves[348] = shelf349;
            shelves[349] = shelf350;
            shelves[350] = shelf351;
            shelves[351] = shelf352;
            shelves[352] = shelf353;
            shelves[353] = shelf354;
            shelves[354] = shelf355;
            shelves[355] = shelf356;
            shelves[356] = shelf357;
            shelves[357] = shelf358;
            shelves[358] = shelf359;
            shelves[359] = shelf360;
            shelves[360] = shelf361;
            shelves[361] = shelf362;
            shelves[362] = shelf363;
            shelves[363] = shelf364;
            shelves[364] = shelf365;
            shelves[365] = shelf366;
            shelves[366] = shelf367;
            shelves[367] = shelf368;
            shelves[368] = shelf369;
            shelves[369] = shelf370;
            shelves[370] = shelf371;
            shelves[371] = shelf372;
            shelves[372] = shelf373;
            shelves[373] = shelf374;
            shelves[374] = shelf375;
            shelves[375] = shelf376;
            shelves[376] = shelf377;
            shelves[377] = shelf378;
            shelves[378] = shelf379;
            shelves[379] = shelf380;
            shelves[380] = shelf381;
            shelves[381] = shelf382;
            shelves[382] = shelf383;
            shelves[383] = shelf384;
            shelves[384] = shelf385;
            shelves[385] = shelf386;
            shelves[386] = shelf387;
            shelves[387] = shelf388;
            shelves[388] = shelf389;
            shelves[389] = shelf390;
            shelves[390] = shelf391;
            shelves[391] = shelf392;
            shelves[392] = shelf393;
            shelves[393] = shelf394;

            //Extra shelves on top floor SW
            shelves[394] = shelf539;
            shelves[395] = shelf540;
            shelves[396] = shelf541;
            shelves[397] = shelf542;
            shelves[398] = shelf543;
            shelves[399] = shelf544;
            shelves[400] = shelf545;
            shelves[401] = shelf546;
            shelves[402] = shelf547;

            shelves[403] = shelf395;
            shelves[404] = shelf396;
            shelves[405] = shelf397;
            shelves[406] = shelf398;
            shelves[407] = shelf399;
            shelves[408] = shelf400;
            shelves[409] = shelf401;
            shelves[410] = shelf402;
            shelves[411] = shelf403;
            shelves[412] = shelf404;
            shelves[413] = shelf405;
            shelves[414] = shelf406;
            shelves[415] = shelf407;
            shelves[416] = shelf408;
            shelves[417] = shelf409;
            shelves[418] = shelf410;
            shelves[419] = shelf411;
            shelves[420] = shelf412;
            shelves[421] = shelf413;
            shelves[422] = shelf414;
            shelves[423] = shelf415;
            shelves[424] = shelf416;
            shelves[425] = shelf417;
            shelves[426] = shelf418;
            shelves[427] = shelf419;
            shelves[428] = shelf420;
            shelves[429] = shelf421;
            shelves[430] = shelf422;
            shelves[431] = shelf423;
            shelves[432] = shelf424;
            shelves[433] = shelf425;
            shelves[434] = shelf426;
            shelves[435] = shelf427;
            shelves[436] = shelf428;
            shelves[437] = shelf429;
            shelves[438] = shelf430;
            shelves[439] = shelf431;
            shelves[440] = shelf432;
            shelves[441] = shelf433;
            shelves[442] = shelf434;
            shelves[443] = shelf435;
            shelves[444] = shelf436;
            shelves[445] = shelf437;
            shelves[446] = shelf438;
            shelves[447] = shelf439;
            shelves[448] = shelf440;
            shelves[449] = shelf441;
            shelves[450] = shelf442;
            shelves[451] = shelf443;
            shelves[452] = shelf444;
            shelves[453] = shelf445;
            shelves[454] = shelf446;
            shelves[455] = shelf447;
            shelves[456] = shelf448;
            shelves[457] = shelf449;
            shelves[458] = shelf450;
            shelves[459] = shelf451;
            shelves[460] = shelf452;
            shelves[461] = shelf453;
            shelves[462] = shelf454;
            shelves[463] = shelf455;
            shelves[464] = shelf456;
            shelves[465] = shelf457;
            shelves[466] = shelf458;
            shelves[467] = shelf459;
            shelves[468] = shelf460;
            shelves[469] = shelf461;
            shelves[470] = shelf462;
            shelves[471] = shelf463;
            shelves[472] = shelf464;
            shelves[473] = shelf465;
            shelves[474] = shelf466;
            shelves[475] = shelf467;
            shelves[476] = shelf468;
            shelves[477] = shelf469;
            shelves[478] = shelf470;
            shelves[479] = shelf471;
            shelves[480] = shelf472;
            shelves[481] = shelf473;
            shelves[482] = shelf474;
            shelves[483] = shelf475;
            shelves[484] = shelf476;
            shelves[485] = shelf477;
            shelves[486] = shelf478;
            shelves[487] = shelf479;
            shelves[488] = shelf480;
            shelves[489] = shelf481;
            shelves[490] = shelf482;
            shelves[491] = shelf483;
            shelves[492] = shelf484;
            shelves[493] = shelf485;
            shelves[494] = shelf486;
            shelves[495] = shelf487;
            shelves[496] = shelf488;
            shelves[497] = shelf489;
            shelves[498] = shelf490;
            shelves[499] = shelf491;
            shelves[500] = shelf492;
            shelves[501] = shelf493;
            shelves[502] = shelf494;
            shelves[503] = shelf495;
            shelves[504] = shelf496;
            shelves[505] = shelf497;
            shelves[506] = shelf498;
            shelves[507] = shelf499;
            shelves[508] = shelf500;
            shelves[509] = shelf501;
            shelves[510] = shelf502;
            shelves[511] = shelf503;
            shelves[512] = shelf504;
            shelves[513] = shelf505;
            shelves[514] = shelf506;
            shelves[515] = shelf507;
            shelves[516] = shelf508;
            shelves[517] = shelf509;
            shelves[518] = shelf510;
            shelves[519] = shelf511;
            shelves[520] = shelf512;
            shelves[521] = shelf513;
            shelves[522] = shelf514;
            shelves[523] = shelf515;
            shelves[524] = shelf516;
            shelves[525] = shelf517;
            shelves[526] = shelf518;
            shelves[527] = shelf519;
            shelves[528] = shelf520;
            shelves[529] = shelf521;
            shelves[530] = shelf522;
            shelves[531] = shelf523;
            shelves[532] = shelf524;
            shelves[533] = shelf525;
            shelves[534] = shelf526;
            shelves[535] = shelf527;
            shelves[536] = shelf528;
            shelves[537] = shelf529;
            shelves[538] = shelf530;
            shelves[539] = shelf531;
            shelves[540] = shelf532;
            shelves[541] = shelf533;
            shelves[542] = shelf534;
            shelves[543] = shelf535;
            shelves[544] = shelf536;
            shelves[545] = shelf537;
            shelves[546] = shelf538;

            foreach (Button shelf in shelves)
            {
                shelf.Click += Shelf_Click;
            }
        }

        /*
         * Adds the label (TextBlock) for a found book/manuscript
         * Shelf index and number of the book are given as parameters
         * Also updates the room's label for all books
         */
        private void MarkBookForShelf(int shelf, int book)
        {
            Thickness margin = new Thickness(shelves[shelf].Margin.Left - 12,
                                                shelves[shelf].Margin.Top - 12,
                                                mainGrid.ActualWidth - shelves[shelf].Margin.Left - 20,
                                                mainGrid.ActualHeight - shelves[shelf].Margin.Top - 20);

            int room = GetRoomForShelf(shelf);

            //Search if there are previously a label on the same spot to replace
            bool dontContinue = false;
            foreach (TextBlock label in labels)
            {
                if (label.Margin.Equals(margin))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (foundBooksByRoom[room, i] == (label.Text.Equals("M")? 0 : Int32.Parse(label.Text)))
                        {
                            foundBooksByRoom[room, i] = book;
                            break;
                        }
                    }
                    
                    label.Text = book == 0 ? "M" : book.ToString();
                    dontContinue = true;
                    break;
                }
            }

            if (!dontContinue)
            {
                //Shadow effect to make the text slightly easier to read
                DropShadowEffect dropShadowEffect = new DropShadowEffect
                {
                    Color = Colors.Black,
                    BlurRadius = 0,
                    Direction = 0,
                    ShadowDepth = 0,
                    Opacity = 1
                };

                //The actual TextBlock object
                TextBlock bookText = new TextBlock
                {
                    Text = book == 0 ? "M" : book.ToString(),
                    TextAlignment = TextAlignment.Center,
                    FontSize = 20,
                    FontWeight = FontWeights.Bold,
                    Foreground = Brushes.White,
                    IsHitTestVisible = false,
                    Effect = dropShadowEffect,
                    Margin = margin
                };

                //Adding to found books
                for (int i = 0; i < 4; i++)
                {
                    if (foundBooksByRoom[room, i] == -1)
                    {
                        foundBooksByRoom[room, i] = book;
                        break;
                    }
                }

                //Add the label to the grid and label list (so that we can remove it from the grid when reset-button is pressed)
                mainGrid.Children.Add(bookText);
                labels.Add(bookText);
            }

            //Updating the room labels for found books
            TextBlock labelToUpdate = null;
            string text = "";
            if (room == 0)
                labelToUpdate = roomBooks1;
            else if(room == 1)
                labelToUpdate = roomBooks2;
            else if (room == 2)
                labelToUpdate = roomBooks3;
            else if (room == 3)
                labelToUpdate = roomBooks4;
            else if (room == 4)
                labelToUpdate = roomBooks5;
            else if (room == 5)
                labelToUpdate = roomBooks6;
            else if (room == 6)
                labelToUpdate = roomBooks7;
            else if (room == 7)
                labelToUpdate = roomBooks8;
            else if (room == 8)
                labelToUpdate = roomBooks9;
            else if (room == 9)
                labelToUpdate = roomBooks10;
            else
                labelToUpdate = roomBooks11;

            for (int i = 0; i < 4; i++)
            {
                int bookNumber = foundBooksByRoom[room, i];
                if (bookNumber != -1)
                {
                    text += bookNumber == 0 ? "M" : bookNumber.ToString();
                    text += ", ";
                }
            }
            if (text.Length > 1)
                text = text.Substring(0, text.Length - 2);
            labelToUpdate.Text = text;
        }

        /* 
         * Marks shelves that are possible when the first found shelf is the parameter
         */
        private void MarkPossibleShelves(int shelf)
        {
            int startIndex = shelf;

            shelves[startIndex].Style = confirmedShelf;

            //Clockwise
            int counter         = jumpDistance-1;
            int MarkedShelves   = 0;
            for (int i = 0; i < shelves.Length; i++)
            {
                int shelfIndex = (i + startIndex + 1) % shelves.Length;

                //Skip dead shelves
                if (!shelves[shelfIndex].IsEnabled)
                    continue;
                    
                //Mark the shelf or lower counter
                if (counter == 0)
                {   
                    shelves[shelfIndex].Style = possibleShelfForwards;
                    counter = jumpDistance-1;

                    possibleShelvesForwards[MarkedShelves] = shelfIndex;
                    MarkedShelves++;
                    if (MarkedShelves == books-1) break;
                }
                else 
                    counter--;
            }
            
            //Counter clockwise
            counter         = jumpDistance-1;
            MarkedShelves   = 0;
            for (int i = 0; i < shelves.Length; i++)
            {
                int baseIndex = (startIndex - i-1);

                int shelfIndex = (baseIndex < 0? shelves.Length+baseIndex : baseIndex) % shelves.Length;

                //Skip dead shelves
                if (!shelves[shelfIndex].IsEnabled)
                    continue;

                //Mark the shelf or lower counter
                if (counter == 0)
                {
                    shelves[shelfIndex].Style = possibleShelfBackwards;
                    counter = jumpDistance-1;

                    possibleShelvesBackwards[MarkedShelves] = shelfIndex;
                    MarkedShelves++;
                    if (MarkedShelves == books-1) break;
                }
                else
                    counter--;
            }
        }

        /*
         * Changes the styles of some possible shelves and the new found shelf
         */
        private void NewBookFound(int shelf)
        {
            for (int k = 0; k < books-1; k++)
            {
                if (possibleShelvesBackwards[k] == shelf)
                {
                    for (int b = 0; b <= k; b++)
                    {
                        shelves[possibleShelvesBackwards[b]].Style = confirmedShelf;
                        shelves[possibleShelvesForwards[books - 2 - b]].Style = basicShelf;
                    }

                    break;
                } else if (possibleShelvesForwards[k] == shelf)
                {
                    for (int b = 0; b <= k; b++)
                    {
                        shelves[possibleShelvesForwards[b]].Style = confirmedShelf;
                        shelves[possibleShelvesBackwards[books - 2 - b]].Style = basicShelf;
                    }

                    break;
                }
            }
        }

        private void ResetShelves()
        {
            //Reset shelf styles
            for (uint i = 0; i < shelves.Length; i++)
            {
                shelves[i].Style = basicShelf;
            }

            //Remove labels
            foreach (TextBlock label in labels)
            {
                if (label != null)
                    mainGrid.Children.Remove(label);
            }

            //Reset found books
            foundBooksByRoom = new int[11, 4] { { -1, -1, -1, -1 },
                                                { -1, -1, -1, -1 },
                                                { -1, -1, -1, -1 },
                                                { -1, -1, -1, -1 },
                                                { -1, -1, -1, -1 },
                                                { -1, -1, -1, -1 },
                                                { -1, -1, -1, -1 },
                                                { -1, -1, -1, -1 },
                                                { -1, -1, -1, -1 },
                                                { -1, -1, -1, -1 },
                                                { -1, -1, -1, -1 } };
            roomBooks1.Text = "";
            roomBooks2.Text = "";
            roomBooks3.Text = "";
            roomBooks4.Text = "";
            roomBooks5.Text = "";
            roomBooks6.Text = "";
            roomBooks7.Text = "";
            roomBooks8.Text = "";
            roomBooks9.Text = "";
            roomBooks10.Text = "";
            roomBooks11.Text = "";

            labels = new List<TextBlock>();

            firstShelf = -1;
            initialClick = true;
        }

        public MainWindow()
        {
            InitializeComponent();
            InitializeShelves();

            basicShelf              = FindResource("BasicShelf") as Style;
            confirmedShelf          = FindResource("ConfirmedBookShelf") as Style;
            possibleShelfForwards   = FindResource("PossibleBookShelfForwards") as Style;
            possibleShelfBackwards  = FindResource("PossibleBookShelfBackwards") as Style;

            //Reseting everything just to be sure no temporary texts or anything is present
            ResetShelves();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ResetShelves();
            lastReseted.Text = "Latest reset: " + DateTime.UtcNow.ToLongTimeString() + " utc";
        }
        
        private void Shelf_Click(object sender, RoutedEventArgs e)
        {
            int shelfIndex = Array.IndexOf(shelves, sender as Button);

            //Skip if not possible shelf
            if (!initialClick && shelves[shelfIndex].Style.Equals(basicShelf))
                return;

            //Coloring the shelves
            if (initialClick)
            {
                initialClick = false;
                MarkPossibleShelves(shelfIndex);
                firstShelf = shelfIndex;
            }
            else
            {
                NewBookFound(shelfIndex);
            }

            //Prompt to get the book that was found
            //Using the public static variable 'newestBook' to get the information
            BookPrompt bookPrompt = new BookPrompt();
            bookPrompt.Left = this.Left + (this.ActualWidth - bookPrompt.Width) / 2;
            bookPrompt.Top = this.Top + (this.ActualHeight - bookPrompt.Height) / 2;

            bool? result = bookPrompt.ShowDialog();
            if (result == true)
            {
                MarkBookForShelf(shelfIndex, newestBook);
            }
        }

        private void export_Click(object sender, RoutedEventArgs e)
        {
            //Try-catch because creating the file might throw error if access is denied (run as adminstrator in that case)
            try
            {
                //Form the RenderTargetBitmap object
                double dpi = 97;           //dpi
                var rtb = new RenderTargetBitmap(
                    (int)this.Width,        //width
                    (int)this.Height,       //height
                    dpi,                    //dpi x
                    dpi,                    //dpi y
                    PixelFormats.Pbgra32    // pixelformat
                    );
                rtb.Render(this);

                //Encoder
                var enc = new System.Windows.Media.Imaging.PngBitmapEncoder();
                enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(rtb));

                //Actually create the file and save the window screenshot there
                using (var stm = System.IO.File.Create("Arceuus library " + DateTime.UtcNow + " utc.png"))
                {
                    enc.Save(stm);
                }

                lastExported.Text = "Latest export: " + DateTime.UtcNow.ToLongTimeString() + " utc";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
    }
}
