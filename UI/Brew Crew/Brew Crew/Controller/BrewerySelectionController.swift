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
    
//    let sendButton: UIButton = {
//        let button = UIButton(type: .system)
//        button.backgroundColor = .clear
//        button.translatesAutoresizingMaskIntoConstraints = false
//        button.setBackgroundImage(UIImage(systemName: "circle"), for: .normal)
//        button.addTarget(self, action: #selector(handleSendButton), for: .touchUpInside)
//        return button
//    }()
    
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        tableView.delegate = self
        tableView.dataSource = self
        navigationController?.navigationBar.isHidden = false
        tableView.register(BreweryCell.self, forCellReuseIdentifier: breweryCellId)
        view.addSubview(tableView)
        //view.addSubview(sendButton)
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
        guard let breweries_ = breweries else {return}
        let bsc = BeerSelectionController()
        bsc.breweryId = breweries_[indexPath.item].ID
        bsc.user = user
        bsc.breweryName = breweries_[indexPath.item].Name
        navigationController?.pushViewController(bsc, animated: true)
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
