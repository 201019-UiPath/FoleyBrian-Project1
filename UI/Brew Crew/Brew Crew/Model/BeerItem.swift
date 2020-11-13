//import AVFoundation
//
//struct BeerItem: Codable {
//    var ID, BreweryID, BeerID: String?
//    var Brewery_: Brewery?
//    var Beer_: Beer?
//    var Keg: Int?
//    
//    enum CodingKeys: String, CodingKey {
//        case ID = "id"
//        case BeerID = "beerid"
//        case BreweryID = "breweryid"
//        case Beer_ = "beer"
//        case Brewery_ = "brewery"
//        case Keg = "keg"
//    }
//    
//    public init(from decoder: Decoder) throws {
//        let container = try decoder.container(keyedBy: CodingKeys.self)
//        BeerID = try container.decode(String.self, forKey: .BeerID)
//        BreweryID = try container.decode(String.self, forKey: .BreweryID)
//        ID = try container.decode(String.self, forKey: .ID)
//        Beer_ = try container.decode(Beer.self, forKey: .Beer_)
//        Brewery_ = try container.decode(Brewery.self, forKey: .Brewery_)
//        Keg = try container.decode(Int.self, forKey: .Keg)
//    }
//    
//    public init()
//    {
//        
//    }
//}

