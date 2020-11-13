import AVFoundation

struct Beer: Codable {
    var ID, Name, `Type`, BreweryID: String?
    var ABV, Price: Double?
    var IBU, Keg: Int?
    
    enum CodingKeys: String, CodingKey {
        case ID = "id"
        case Name = "name"
        case `Type` = "type"
        case ABV = "abv"
        case IBU = "ibu"
        case Price = "price"
        case BreweryID = "breweryID"
        case Keg = "keg"
    }
    
    public init(from decoder: Decoder) throws {
        let container = try decoder.container(keyedBy: CodingKeys.self)
        ID = try container.decode(String.self, forKey: .ID)
        Price = try container.decode(Double.self, forKey: .Price)
        IBU = try container.decode(Int.self, forKey: .IBU)
        ABV = try container.decode(Double.self, forKey: .ABV)
        `Type` = try container.decode(String.self, forKey: .`Type`)
        Name = try container.decode(String.self, forKey: .Name)
        Keg = try container.decode(Int.self, forKey: .Keg)
        BreweryID = try container.decode(String.self, forKey: .BreweryID)
    }
    
    public init()
    {
        
    }
}

