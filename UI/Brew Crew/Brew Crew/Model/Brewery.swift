import AVFoundation

struct Brewery: Codable {
    var ID, Name, State, City, Address: String?
    var Zip: Int?
    var Beers: [Beer]?
    var Orders: [Order]?
    var BreweryManagers: [BreweryManager]?
    
    enum CodingKeys: String, CodingKey {
        case ID = "id"
        case Name = "name"
        case State = "state"
        case City = "city"
        case Address = "address"
        case Zip = "zip"
        case Beers = "beers"
        case Orders = "orders"
        case BreweryManagers = "breweryManagers"
    }
    
    public init(from decoder: Decoder) throws {
        let container = try decoder.container(keyedBy: CodingKeys.self)
        ID = try container.decode(String.self, forKey: .ID)
        Name = try container.decode(String.self, forKey: .Name)
        State = try container.decode(String.self, forKey: .State)
        City = try container.decode(String.self, forKey: .City)
        Address = try container.decode(String.self, forKey: .Address)
        Zip = try container.decode(Int.self, forKey: .Zip)
        do {
            Beers = try container.decode([Beer].self, forKey: .Beers)
        } catch {
        }
        do {
            Orders = try container.decode([Order].self, forKey: .Orders)
        } catch {
            
        }
        do {
            BreweryManagers = try container.decode([BreweryManager].self, forKey: .BreweryManagers)
        } catch {
            
        }
    }
    
    public init()
    {
        
    }
}


