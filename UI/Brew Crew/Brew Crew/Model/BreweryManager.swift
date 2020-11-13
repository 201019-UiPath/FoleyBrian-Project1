import AVFoundation

struct BreweryManager: Codable {
    var ID, BreweryID, UserID: String?
    var Brewery_: Brewery?
    var User_: User?
    
    enum CodingKeys: String, CodingKey {
        case ID = "id"
        case UserID = "userID"
        case BreweryID = "breweryID"
        case User_ = "user"
    }
    
    public init(from decoder: Decoder) throws {
        let container = try decoder.container(keyedBy: CodingKeys.self)
        UserID = try container.decode(String.self, forKey: .UserID)
        BreweryID = try container.decode(String.self, forKey: .BreweryID)
        ID = try container.decode(String.self, forKey: .ID)
        do {
            User_ = try container.decode(User.self, forKey: .User_)
        } catch {
            
        }
    }
    
    public init()
    {
        
    }
}


