import AVFoundation

struct Order: Codable {
    var ID, UserID, BreweryID: String?
    var TableNumber: Int?
    var TotalPrice: Double?
    var DateTime: Date? = Date()
    var User_: User?
    var LineItems: [LineItem]?
    
    enum CodingKeys: String, CodingKey {
        case ID = "id"
        case UserID = "userID"
        case BreweryID = "breweryID"
        case TableNumber = "tableNumber"
        case TotalPrice = "totalPrice"
        case DateTime = "date"
        case LineItems = "lineItems"
    }
    
    public init(from decoder: Decoder) throws {
        let container = try decoder.container(keyedBy: CodingKeys.self)
        UserID = try container.decode(String.self, forKey: .UserID)
        BreweryID = try container.decode(String.self, forKey: .BreweryID)
        ID = try container.decode(String.self, forKey: .ID)
        TableNumber = try container.decode(Int.self, forKey: .TableNumber)
        TotalPrice = try container.decode(Double.self, forKey: .TotalPrice)
        do {
            DateTime = try container.decode(Date.self, forKey: .DateTime)
        } catch {
        }
        do {
            LineItems = try container.decode([LineItem].self, forKey: .LineItems)
        } catch {
            
        }
        
    }
    
    public init()
    {
        
    }
}


