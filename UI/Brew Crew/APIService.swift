//
//  APIService.swift
//  Brew Crew
//
//  Created by Brian Foley on 11/9/20.
//

import UIKit
import Foundation

class APIService: NSObject, URLSessionDelegate {
    static let shared = APIService()
    
    func validateSignIn(email: String, password: String, completion: @escaping(Bool, User?) -> ()) {
        let session = URLSession(configuration: URLSessionConfiguration.default, delegate: self, delegateQueue: OperationQueue.main)
        if let url = URL(string: "https://localhost:47720/api/user/get/login/\(email)") {
            session.dataTask(with: url) { data, response, error in
                if let data = data {
                    if let jsonString = String(data: data, encoding: .utf8) {
                        if let jsonData = jsonString.data(using: .utf8) {
                            do {
                                let decoder = JSONDecoder()
                                decoder.keyDecodingStrategy = .convertFromSnakeCase
                                let user = try decoder.decode(User.self, from: jsonData)
                                if password == user.Password
                                {
                                    DispatchQueue.main.async {
                                        completion(true, user)
                                    }
                                } else {
                                    DispatchQueue.main.async {
                                        completion(false, user)
                                    }
                                }
                            } catch {
                                DispatchQueue.main.async {
                                    completion(false, nil)
                                }
                            }
                        }
                    }
                } else {
                    DispatchQueue.main.async {
                        completion(false, nil)
                    }
                }
            }.resume()
        }
    }
    
    func registerUser(firstName: String, lastName: String, email: String, password: String, completion: @escaping(Bool, User?) -> ()) {
        let session = URLSession(configuration: URLSessionConfiguration.default, delegate: self, delegateQueue: OperationQueue.main)
        if let url = URL(string: "https://localhost:47720/api/user/add") {
            var user = User()
            user.ID = NSUUID().uuidString
            user.FName = firstName
            user.LName = lastName
            user.Email = email
            user.Password = password
            user.Type = "customer"
            do {
                let encoder = JSONEncoder()
                encoder.dateEncodingStrategy = .formatted(.iso8601Full)
                let jsonData = try encoder.encode(user)
                var request = URLRequest(url: url)
                request.httpMethod = "POST"
                request.httpBody = jsonData
                request.setValue("application/json", forHTTPHeaderField: "Content-Type")
                session.dataTask(with: request) { data, response, error in
                    if let err = error {
                        print("Error", err)
                        completion(false, nil)
                    } else {
                        completion(true, user)
                    }
                }.resume()
            } catch {
                print(error)
                completion(false, nil)
            }
            
        }
    }
    
    func fetchAllBreweries(completion: @escaping([Brewery]) -> ()) {
        let session = URLSession(configuration: URLSessionConfiguration.default, delegate: self, delegateQueue: OperationQueue.main)
        
        if let url = URL(string: "https://localhost:47720/api/brewery/GetAll") {
            session.dataTask(with: url) { data, response, error in
                if let data = data {
                    if let jsonString = String(data: data, encoding: .utf8) {
                        if let jsonData = jsonString.data(using: .utf8) {
                            do {
                                let decoder = JSONDecoder()
                                decoder.keyDecodingStrategy = .convertFromSnakeCase
                                decoder.dateDecodingStrategy = .formatted(.iso8601Full)
                                let breweries = try decoder.decode([Brewery].self, from: jsonData)
                                DispatchQueue.main.async {
                                    completion(breweries)
                                }
                            } catch {
                                print(error)
                            }
                        }
                    }
                }
            }.resume()
        }
    }
    
    func fetchBrewerybyId(breweryId: String, completion: @escaping(Brewery) -> ()) {
        let session = URLSession(configuration: URLSessionConfiguration.default, delegate: self, delegateQueue: OperationQueue.main)
        
        if let url = URL(string: "https://localhost:47720/api/brewery/Get/\(breweryId)") {
            session.dataTask(with: url) { data, response, error in
                if let data = data {
                    if let jsonString = String(data: data, encoding: .utf8) {
                        if let jsonData = jsonString.data(using: .utf8) {
                            do {
                                let decoder = JSONDecoder()
                                decoder.keyDecodingStrategy = .convertFromSnakeCase
                                decoder.dateDecodingStrategy = .formatted(.iso8601Full)
                                let brewery = try decoder.decode(Brewery.self, from: jsonData)
                                DispatchQueue.main.async {
                                    completion(brewery)
                                }
                            } catch {
                                print(error)
                            }
                        }
                    }
                }
            }.resume()
        }
    }
    
    func fetchAllBeersByBreweryId(id: String, completion: @escaping([Beer]) -> ()) {
        let session = URLSession(configuration: URLSessionConfiguration.default, delegate: self, delegateQueue: OperationQueue.main)
        let urlstring = "https://localhost:47720/api/beer/get/brewery/\(id)"
        if let url = URL(string: urlstring) {
            session.dataTask(with: url) { data, response, error in
                if let data = data {
                    if let jsonString = String(data: data, encoding: .utf8) {
                        print(jsonString)
                        if jsonString == "" {return}
                        if let jsonData = jsonString.data(using: .utf8) {
                            do {
                                let decoder = JSONDecoder()
                                decoder.keyDecodingStrategy = .convertFromSnakeCase
                                decoder.dateDecodingStrategy = .formatted(.iso8601Full)
                                let beers = try decoder.decode([Beer].self, from: jsonData)
                                DispatchQueue.main.async {
                                    completion(beers)
                                }
                            } catch {
                                print(error)
                            }
                        }
                    }
                }
            }.resume()
        }
    }
    
    func placeOrder(beers: [Beer], breweryId: String, userId: String, total: Double, tableNumber: Int, completion: @escaping(Bool) -> ()) {
        let session = URLSession(configuration: URLSessionConfiguration.default, delegate: self, delegateQueue: OperationQueue.main)
        var order = Order()
        order.ID = NSUUID().uuidString
        order.DateTime = Date()
        order.BreweryID = breweryId
        order.UserID = userId
        order.TotalPrice = total
        order.TableNumber = tableNumber
        var lineItems = [LineItem]()
        for beer in beers {
            var lineitem = LineItem()
            lineitem.BeerID = beer.ID
            lineitem.ID = NSUUID().uuidString
            lineitem.OrderID = order.ID
            lineItems.append(lineitem)
        }
        order.LineItems = lineItems
        if let url = URL(string: "https://localhost:47720/api/order/add") {
            do {
                let encoder = JSONEncoder()
                encoder.dateEncodingStrategy = .formatted(.iso8601Full)
                let jsonData = try encoder.encode(order)
                var request = URLRequest(url: url)
                if let jsonString = String(data: jsonData, encoding: .utf8) {
                    print(jsonString)
                }
                request.httpMethod = "POST"
                request.httpBody = jsonData
                request.setValue("application/json", forHTTPHeaderField: "Content-Type")
                session.dataTask(with: request) { data, response, error in
                    if let err = error {
                        print("Error", err)
                        completion(false)
                    } else {
                        completion(true)
                    }
                }.resume()
            } catch {
                print(error)
                completion(false)
            }
        }
    }
    
    func fetchAllOrdersByUserId(id: String, completion: @escaping([Order]) -> ()) {
        let session = URLSession(configuration: URLSessionConfiguration.default, delegate: self, delegateQueue: OperationQueue.main)
        let urlstring = "https://localhost:47720/api/order/get/user/\(id)"
        if let url = URL(string: urlstring) {
            session.dataTask(with: url) { data, response, error in
                if let data = data {
                    if let jsonString = String(data: data, encoding: .utf8) {
                        if jsonString == "" {return}
                        if let jsonData = jsonString.data(using: .utf8) {
                            do {
                                let decoder = JSONDecoder()
                                decoder.keyDecodingStrategy = .convertFromSnakeCase
                                decoder.dateDecodingStrategy = .formatted(.iso8601Full)
                                let orders = try decoder.decode([Order].self, from: jsonData)
                                DispatchQueue.main.async {
                                    completion(orders)
                                }
                            } catch {
                                print(error)
                            }
                        }
                    }
                }
            }.resume()
        }
    }
    
    func urlSession(_ session: URLSession, didReceive challenge: URLAuthenticationChallenge, completionHandler: (URLSession.AuthChallengeDisposition, URLCredential?) -> Void) {
            completionHandler(.useCredential, URLCredential(trust: challenge.protectionSpace.serverTrust!))
    }
}

extension DateFormatter {
  static let iso8601Full: DateFormatter = {
    let formatter = DateFormatter()
    formatter.dateFormat = "yyyy-MM-dd'T'HH:mm:ss.SSSXXX"
    formatter.calendar = Calendar(identifier: .iso8601)
    formatter.timeZone = TimeZone(secondsFromGMT: 0)
    formatter.locale = Locale(identifier: "en_US_POSIX")
    return formatter
  }()
}


