import AVFoundation

struct LineItem: Codable {
    var ID, OrderID, BeerID: String?
    var Beer_ :Beer?
    
    enum CodingKeys: String, CodingKey {
        case ID = "id"
        case OrderID = "orderID"
        case BeerID = "beerID"
        case Beer_ = "beer"
    }
    
    public init(from decoder: Decoder) throws {
        let container = try decoder.container(keyedBy: CodingKeys.self)
        OrderID = try container.decode(String.self, forKey: .OrderID)
        BeerID = try container.decode(String.self, forKey: .BeerID)
        ID = try container.decode(String.self, forKey: .ID)
        do {
        Beer_ = try container.decode(Beer.self, forKey: .Beer_)
        } catch {
            
        }
    }
    
    public init()
    {
        
    }
}

