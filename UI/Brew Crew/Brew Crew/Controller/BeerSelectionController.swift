//
//  BeerSelectionController.swift
//  Brew Crew
//
//  Created by Brian Foley on 11/11/20.
//


import Foundation
import UIKit

class BeerSelectionController: UIViewController, UITableViewDelegate, UITableViewDataSource {
    
    let beerCellId = "beercellId"
    
    var beers: [Beer]? {
        didSet{
            tableView.reloadData()
        }
    }

    var user: User?
    var breweryId: String?
    var breweryName: String?
    var image: UIImage?
    
    
    let tableView: UITableView = {
        let tableView = UITableView()
        tableView.translatesAutoresizingMaskIntoConstraints = false
        tableView.backgroundColor = .color2
        return tableView
    }()
        
    lazy var cartButton: UIButton = {
        let button = UIButton(type: .system)
        button.backgroundColor = .clear
        button.setBackgroundImage(UIImage(systemName: "cart"), for: .normal)
        button.addTarget(self, action: #selector(handleCartButton), for: .touchUpInside)
        return button
    }()
    
    lazy var orderHistoryButton: UIButton = {
        let button = UIButton(type: .system)
        button.backgroundColor = .clear
        button.setBackgroundImage(UIImage(systemName: "clock"), for: .normal)
        button.addTarget(self, action: #selector(handleOrderHistoryButton), for: .touchUpInside)
        return button
    }()
    
    
    override func viewDidLoad() {
        super.viewDidLoad()
        view.backgroundColor = .color3
        tableView.delegate = self
        tableView.dataSource = self
        navigationController?.navigationBar.isHidden = false
        tableView.register(BeerCell.self, forCellReuseIdentifier: beerCellId)
        view.addSubview(tableView)
        setupConstraints()
        tableView.reloadData()
        title = "\(breweryName!)"
    }
    
    override func viewWillAppear(_ animated: Bool) {
        super.viewWillAppear(true)
        APIService.shared.fetchAllBeersByBreweryId(id:breweryId!) { (beers) in
            self.beers = beers
        }
        setupNavBar()
    }
    
    func setupConstraints() {
        tableView.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        tableView.centerYAnchor.constraint(equalTo: view.centerYAnchor).isActive = true
        tableView.heightAnchor.constraint(equalTo: view.heightAnchor).isActive = true
        tableView.widthAnchor.constraint(equalTo: view.widthAnchor).isActive = true
    }
    
    internal func setupNavBar() {
        navigationItem.rightBarButtonItems = [UIBarButtonItem(customView: cartButton), UIBarButtonItem(customView: orderHistoryButton)]
    }
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return beers?.count ?? 0
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: beerCellId, for: indexPath) as? BeerCell
        if let beers = self.beers {
            cell!.beer = beers[indexPath.item]
        }
        return cell!
    }

    func tableView(_ tableView: UITableView, heightForRowAt indexPath: IndexPath) -> CGFloat {
        return 70
    }
    
    @objc func handleCartButton() {
        let cartController = CartController()
        cartController.breweryId = breweryId
        cartController.user = user
        navigationController?.pushViewController(cartController, animated: true)
    }
    
    @objc func handleOrderHistoryButton() {
        let ohc = OrderHistoryController()
        ohc.userId = user?.ID
        navigationController?.pushViewController(ohc, animated: true)
    }
}

