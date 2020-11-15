//
//  BrewerySelectionController.swift
//  Brew Crew
//
//  Created by Brian Foley on 11/11/20.
//

import Foundation
import UIKit

class BrewerySelectionController: UIViewController, UITableViewDelegate, UITableViewDataSource {
    
    let breweryCellId = "brewerycellId"
    var breweries: [Brewery]? {
        didSet{
            tableView.reloadData()
        }
    }

    var image: UIImage?
    var user: User?
    
    let tableView: UITableView = {
        let tableView = UITableView()
        tableView.translatesAutoresizingMaskIntoConstraints = false
        tableView.backgroundColor = .color2
        tableView.estimatedRowHeight = 70
        tableView.rowHeight = UITableView.automaticDimension
        return tableView
    }()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        tableView.delegate = self
        tableView.dataSource = self
        navigationController?.navigationBar.isHidden = false
        tableView.register(BreweryCell.self, forCellReuseIdentifier: breweryCellId)
        view.addSubview(tableView)
        setupConstraints()
        title = "Welcome \(user!.FName!)"
    }
    
    override func viewWillAppear(_ animated: Bool) {
        super.viewWillAppear(true)
        setupNavBar()
        CartController.cart.removeAll()
        APIService.shared.fetchAllBreweries { (breweries) in
            self.breweries = breweries
        }
    }
    
    override func viewWillDisappear(_ animated: Bool) {
        super.viewWillDisappear(true)
        title = ""
    }
    
    func setupConstraints() {
        tableView.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        tableView.centerYAnchor.constraint(equalTo: view.centerYAnchor).isActive = true
        tableView.heightAnchor.constraint(equalTo: view.heightAnchor).isActive = true
        tableView.widthAnchor.constraint(equalTo: view.widthAnchor).isActive = true
    }
    
    internal func setupNavBar() {
        navigationController?.navigationBar.barTintColor = .color1
        navigationController?.navigationBar.tintColor = .color2
        navigationController?.navigationBar.titleTextAttributes = [NSAttributedString.Key.foregroundColor : UIColor.color2]
    }
    
    func tableView(_ tableView: UITableView, didSelectRowAt indexPath: IndexPath) {
        guard let breweries_ = breweries else {return}
        let tsc = TableSelectionController()
        tsc.breweryId = breweries_[indexPath.item].ID
        tsc.user = user
        tsc.breweryName = breweries_[indexPath.item].Name
        navigationController?.pushViewController(tsc, animated: true)
    }
    
    func tableView(_ tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return breweries?.count ?? 0
    }
    
    func tableView(_ tableView: UITableView, cellForRowAt indexPath: IndexPath) -> UITableViewCell {
        let cell = tableView.dequeueReusableCell(withIdentifier: breweryCellId, for: indexPath) as? BreweryCell
            cell!.brewery = breweries?[indexPath.item]
        return cell!
    }

    func tableView(_ tableView: UITableView, heightForRowAt indexPath: IndexPath) -> CGFloat {
        return 70
    }
}
