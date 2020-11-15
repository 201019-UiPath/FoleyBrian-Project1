//
//  OrderHistoryCell.swift
//  Brew Crew
//
//  Created by Brian Foley on 11/12/20.
//

import UIKit

class OrderHistoryCell: UITableViewCell {
    
    override func layoutSubviews() {
        super.layoutSubviews()
        setupConstraints()
    }
    
    var order: Order? {
        didSet {
            let df = DateFormatter()
            df.dateFormat = "yyyy-MM-dd"
            textLabel?.text = df.string(from: (order?.DateTime)!)
            guard let breweryID = order?.BreweryID else {return}
            APIService.shared.fetchBrewerybyId(breweryId: breweryID) { (brewery) in
                guard let breweryName = brewery.Name else {return}
                self.detailTextLabel?.text = "\(breweryName)"
            }
        }
    }
    
    override init(style: UITableViewCell.CellStyle, reuseIdentifier: String?) {
        super.init(style: .subtitle, reuseIdentifier: reuseIdentifier)
        self.selectionStyle = SelectionStyle.none
        contentView.isUserInteractionEnabled = false
        backgroundColor = .color3
    }
    
    func setupConstraints() {
        
        textLabel?.frame = CGRect(x: 15, y: textLabel!.frame.origin.y - 2, width: textLabel!.frame.width, height: textLabel!.frame.height )
        
        detailTextLabel?.frame = CGRect(x: 15, y: detailTextLabel!.frame.origin.y + 2, width: detailTextLabel!.frame.width, height: detailTextLabel!.frame.height )
        
    }
        
    required init?(coder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
}

