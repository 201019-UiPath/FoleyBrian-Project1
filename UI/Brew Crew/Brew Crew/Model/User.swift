import AVFoundation

struct User: Codable {
    var ID, FName, LName, Email, Password, `Type`: String?
    var Orders: [Order]?

    enum CodingKeys: String, CodingKey {
        case ID = "id"
        case FName = "fName"
        case LName = "lName"
        case Email = "email"
        case Password = "password"
        case `Type` = "type"
        case Orders = "orders"
    }

    public init(from decoder: Decoder) throws {
        let container = try decoder.container(keyedBy: CodingKeys.self)
        ID = try container.decode(String.self, forKey: .ID)
        FName = try container.decode(String.self, forKey: .FName)
        LName = try container.decode(String.self, forKey: .LName)
        Email = try container.decode(String.self, forKey: .Email)
        Password = try container.decode(String.self, forKey: .Password)
        `Type` = try container.decode(String.self, forKey: .Type)
        do {
            Orders = try container.decode([Order].self, forKey: .Orders)
        } catch {
            
        }
    }

    public init()
    {

    }
}




    







