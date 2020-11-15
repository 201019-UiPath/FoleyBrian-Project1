//
//  OrderHistoryDetailController.swift
//  Brew Crew
//
//  Created by Brian Foley on 11/14/20.
//

import Foundation
import UIKit

class OrderHistoryDetailController: UIViewController, UITableViewDelegate, UITableViewDataSource {
    
    let beerCellId = "beercellId"
    
    var lineItems: [LineItem]? {
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
        tableView.register(OrderHistoryDetailCell.self, forCellReuseIdentifier: beerCellId)
        view.addSubview(tableView)
        setupConstraints()
        tableView.reloadData()
        title = "Order History"
    }
    
    override func viewWillAppear(_ animated: Bool) {
        super.viewWillAppear(true)
    }
    
    func setupConstraints() {
        tableView.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        tableView.centerYAnchor.constraint(equalTo: view.centerYAnchor).isActive = true
        tableView.heightAnchor.constraint(equalTo: view.heightAnchor).isActive = true
        tableView.widthAnchor.constraint(equalTo: view.widthAnchor).isActive = true
    }
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return lineItems?.count ?? 0
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: beerCellId, for: indexPath) as? OrderHistoryDetailCell
        if let lineitems = self.lineItems {
            cell!.beer = lineitems[indexPath.item].Beer_
        }
        return cell!
    }

    func tableView(_ tableView: UITableView, heightForRowAt indexPath: IndexPath) -> CGFloat {
        return 70
    }
}
