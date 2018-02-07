using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyMarket
{
    internal class DatabaseContext
    {
        Dictionary<string, int> _taffy = new Dictionary<string, int>();
        Dictionary<string, int> _candyCoated = new Dictionary<string, int>();
        Dictionary<string, int> _compressedSugar = new Dictionary<string, int>();
        Dictionary<string, int> _zagnut = new Dictionary<string, int>();

        public Dictionary<string, int> CandyCounts = new Dictionary<string, int>();


        /**
         * this is just an example.
         * feel free to modify the definition of this collection "BagOfCandy" if you choose to implement the more difficult data model.
         * Dictionary<CandyType, List<Candy>> BagOfCandy { get; set; }
         */

        public DatabaseContext(int tone) => Console.Beep(tone, 2500);

        internal List<string> GetCandyTypes()
        {
            return Enum
                .GetNames(typeof(CandyType))
                .Select(candyType =>
                    candyType.Humanize(LetterCasing.Title))
                .ToList();
        }

        internal void SaveNewCandy(CandyType candyType, int howMany, string userName)
        {
            if (!_taffy.ContainsKey(userName))
            {
                _taffy.Add(userName, 0);
                _candyCoated.Add(userName, 0);
                _compressedSugar.Add(userName, 0);
                _zagnut.Add(userName, 0);
            }
            switch (candyType)
            {
                case CandyType.TaffyNotLaffy:
                    _taffy[userName] += howMany;
                    break;
                case CandyType.CandyCoated:
                    _candyCoated[userName] += howMany;
                    break;
                case CandyType.CompressedSugar:
                    _compressedSugar[userName] += howMany;
                    break;
                case CandyType.ZagnutStyle:
                    _zagnut[userName] += howMany;
                    break;
                default:
                    break;
            }
        }

        internal bool RemoveCandy(CandyType type, string name)
        {
            switch (type)
            {
                case CandyType.TaffyNotLaffy:
                    if (_taffy[name] > 0)
                    {
                        _taffy[name]--;
                        return true; 
                    }
                    return false; 
                case CandyType.CandyCoated:
                    if (_candyCoated[name] > 0)
                    {
                        _candyCoated[name]--;
                        return true;
                    }
                    return false;
                case CandyType.CompressedSugar:
                    if (_compressedSugar[name] > 0)
                    {
                        _compressedSugar[name]--;
                        return true;
                    }
                    return false;
                case CandyType.ZagnutStyle:
                    if (_zagnut[name] > 0)
                    {
                        _zagnut[name]--;
                        return true;
                    }
                    return false; 
                default:
                    return false;
            }
        }




        //internal void TossCandy(char selectedCandyMenuOption)
        //{
        //    var candyOption = int.Parse(selectedCandyMenuOption.ToString());

        //    var eatenCandy = (CandyType)candyOption;

        //    switch (eatenCandy)
        //    {
        //        case CandyType.TaffyNotLaffy:
        //            if (_countOfTaffy > 0)
        //            {
        //                _countOfTaffy = 0;
        //            }
        //            break;
        //        case CandyType.CandyCoated:
        //            if (_countOfCandyCoated > 0)
        //            {
        //                _countOfCandyCoated = 0;
        //            }
        //            break;
        //        case CandyType.CompressedSugar:
        //            if (_countOfChocolateBar > 0)
        //            {
        //                _countOfChocolateBar = 0;
        //            }
        //            break;
        //        case CandyType.ZagnutStyle:
        //            if (_countOfZagnut > 0)
        //            {
        //                _countOfZagnut = 0;
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}


        //internal void GiveCandy(char selectedCandyMenuOption)
        //{
        //    var candyOption = int.Parse(selectedCandyMenuOption.ToString());
        //    var eatenCandy = (CandyType)candyOption;
        //    int amount; 

        //        switch (eatenCandy)
        //        {
        //            case CandyType.TaffyNotLaffy:
        //            if (_countOfTaffy > 0)
        //            {
        //                amount = GiveAwayAmount(); 
        //                if (amount > 0)
        //                {
        //                    var count = _countOfTaffy - amount;
        //                    _countOfTaffy = (count < 0) ? 0 : count;
        //                }
        //            }
        //                break;
        //            case CandyType.CandyCoated:
        //            if (_countOfCandyCoated > 0)
        //            {
        //                amount = GiveAwayAmount();
        //                if (amount > 0)
        //                {
        //                    var count = _countOfCandyCoated - amount;
        //                    _countOfCandyCoated = (count < 0) ? 0 : count;
        //                }
        //            }
        //                break;
        //            case CandyType.CompressedSugar:
        //                if (_countOfChocolateBar > 0)
        //                {
        //                amount = GiveAwayAmount();
        //                if (amount > 0)
        //                {
        //                    var count = _countOfChocolateBar - amount;
        //                    _countOfChocolateBar = (count < 0) ? 0 : count;
        //                }

        //                }
        //                break;
        //            case CandyType.ZagnutStyle:
        //                if (_countOfZagnut > 0)
        //                {
        //                amount = GiveAwayAmount();
        //                if (amount > 0)
        //                {
        //                    var count = _countOfZagnut - amount;
        //                    _countOfZagnut = (count < 0) ? 0 : count;
        //                }

        //                }
        //                break;
        //            default:
        //                break;
        //    }


        //}

        //internal Dictionary<string, int> GetCandyCounts()
        //{
        //    CandyCounts.Clear();
        //    CandyCounts.Add("TaffyNotLaffy", _countOfTaffy);
        //    CandyCounts.Add("CandyCoated", _countOfCandyCoated);
        //    CandyCounts.Add("CompressedSugar", _countOfChocolateBar);
        //    CandyCounts.Add("ZagnutStyle", _countOfZagnut);

        //    return CandyCounts;
        //}

        //internal int GiveAwayAmount()
        //{
        //    Console.WriteLine();
        //    Console.WriteLine("How much do you want to give away?");
        //    var giveAway = Console.ReadLine();
        //    var amount = int.Parse(giveAway.ToString());
        //    return amount; 
        //}
    }
}