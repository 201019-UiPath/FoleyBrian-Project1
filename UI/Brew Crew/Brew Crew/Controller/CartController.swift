//
//  CartController.swift
//  Brew Crew
//
//  Created by Brian Foley on 11/12/20.
//

import Foundation
import UIKit

class CartController: UIViewController, UITableViewDelegate, UITableViewDataSource {
    
    static var cart = [Beer]()
    static var tableNumber: Int?
    
    let cartCellId = "cartcellId"
    
    var user: User?
    var breweryId: String?
    var image: UIImage?
    
    let tableView: UITableView = {
        let tableView = UITableView()
        tableView.translatesAutoresizingMaskIntoConstraints = false
        tableView.backgroundColor = .color2
        return tableView
    }()
    
    lazy var orderButton: UIButton = {
        let button = UIButton(type: .system)
        button.backgroundColor = .clear
        button.setBackgroundImage(UIImage(systemName: "checkmark.rectangle"), for: .normal)
        button.addTarget(self, action: #selector(handlePlaceOrder), for: .touchUpInside)
        return button
    }()
    
    lazy var resetButton: UIButton = {
        let button = UIButton(type: .system)
        button.backgroundColor = .clear
        button.setBackgroundImage(UIImage(systemName: "arrow.clockwise"), for: .normal)
        button.addTarget(self, action: #selector(handleReset), for: .touchUpInside)
        return button
    }()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        view.backgroundColor = .color3
        tableView.delegate = self
        tableView.dataSource = self
        navigationController?.navigationBar.isHidden = false
        tableView.register(CartCell.self, forCellReuseIdentifier: cartCellId)
        view.addSubview(tableView)
        setupConstraints()
        tableView.reloadData()
        title = "Cart"
        
    }
    
    override func viewWillAppear(_ animated: Bool) {
        super.viewWillAppear(true)
        setupNavBar()
    }
    
    func setupConstraints() {
        tableView.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        tableView.centerYAnchor.constraint(equalTo: view.centerYAnchor).isActive = true
        tableView.heightAnchor.constraint(equalTo: view.heightAnchor).isActive = true
        tableView.widthAnchor.constraint(equalTo: view.widthAnchor).isActive = true
    }
    
    internal func setupNavBar() {
        navigationItem.rightBarButtonItems = [UIBarButtonItem(customView: orderButton), UIBarButtonItem(customView: resetButton)]
    }
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return CartController.cart.count
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: cartCellId, for: indexPath) as? CartCell
        cell!.beer = CartController.cart[indexPath.item]
        return cell!
    }

    func tableView(_ tableView: UITableView, heightForRowAt indexPath: IndexPath) -> CGFloat {
        return 70
    }
    
    @objc func handlePlaceOrder() {
        var totalPrice = Double()
        for beer in CartController.cart {
            guard let price = beer.Price else {continue}
            totalPrice += price
        }
        let beers = CartController.cart
        guard let breweryid = breweryId, let userid = user?.ID, let tableNumber = CartController.tableNumber else {return}
        APIService.shared.placeOrder(beers: beers, breweryId: breweryid, userId: userid, total: totalPrice, tableNumber: tableNumber) { (bool) in
            if bool {
                CartController.cart.removeAll()
                self.tableView.reloadData()
            } else {
                print("Error adding cart")
            }
        }
    }
    
    @objc func handleReset() {
        CartController.cart.removeAll()
        tableView.reloadData()
    }
}
