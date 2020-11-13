//
//  OrderHistoryController.swift
//  Brew Crew
//
//  Created by Brian Foley on 11/12/20.
//

import Foundation
import UIKit

class OrderHistoryController: UIViewController, UITableViewDelegate, UITableViewDataSource {
    
    let orderCellId = "ordercellId"
    
    var orders: [Order]? {
        didSet{
            tableView.reloadData()
        }
    }
    var image: UIImage?
    var userId: String?
    
    let tableView: UITableView = {
        let tableView = UITableView()
        tableView.translatesAutoresizingMaskIntoConstraints = false
        tableView.backgroundColor = .color2
        return tableView
    }()
     
    override func viewDidLoad() {
        super.viewDidLoad()
        view.backgroundColor = .color3
        tableView.delegate = self
        tableView.dataSource = self
        navigationController?.navigationBar.isHidden = false
        tableView.register(OrderHistoryCell.self, forCellReuseIdentifier: orderCellId)
        view.addSubview(tableView)
        //view.addSubview(sendButton)
        setupConstraints()
        tableView.reloadData()
        title = "Order History"
        
    }
    
    override func viewWillAppear(_ animated: Bool) {
        super.viewWillAppear(true)
        APIService.shared.fetchAllOrdersByUserId(id: userId!) { (orders) in
            self.orders = orders
        }
        setupNavBar()
    }
    
//    @objc func handleSendButton() {
//        for cellItem in tableView.indexPathsForSelectedRows! {
//            if cellItem[1] == 0 {
//                //send to gene pool
//                guard let gpimage = self.image else { return }
//                print("Sending to gene Pool")
//                APIService.shared.sendMediaToGenePool(image: gpimage) { (Bool) in
//                    self.navigationController?.popToRootViewController(animated: true)
//                }
//
//            } else {
//                //send to other users
//            }
//        }
//    }
    
    func setupConstraints() {
        tableView.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        tableView.centerYAnchor.constraint(equalTo: view.centerYAnchor).isActive = true
        tableView.heightAnchor.constraint(equalTo: view.heightAnchor).isActive = true
        tableView.widthAnchor.constraint(equalTo: view.widthAnchor).isActive = true
        
//        sendButton.rightAnchor.constraint(equalTo: view.safeAreaLayoutGuide.rightAnchor, constant: -35).isActive = true
//        sendButton.safeAreaLayoutGuide.bottomAnchor.constraint(equalTo: view.safeAreaLayoutGuide.bottomAnchor, constant: -35).isActive = true
//        sendButton.safeAreaLayoutGuide.heightAnchor.constraint(equalToConstant: 44).isActive = true
//        sendButton.safeAreaLayoutGuide.widthAnchor.constraint(equalToConstant: 44).isActive = true
    }
    
    internal func setupNavBar() {
        
    }
    
    func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        guard let cell = tableView.cellForRow(at: indexPath) else { return }
    }
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return orders?.count ?? 0
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: orderCellId, for: indexPath) as? OrderHistoryCell
        if let orders = self.orders {
            cell!.order = orders[indexPath.item]
        }
        return cell!
    }

    func tableView(_ tableView: UITableView, heightForRowAt indexPath: IndexPath) -> CGFloat {
        return 70
    }
}
