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
            detailTextLabel?.text = "Name: \(String((order?.LineItems?[0].Beer_?.Name)!) ) ABV: \(String((order?.LineItems?[0].Beer_?.ABV)!) ) IBUs: \(String((order?.LineItems?[0].Beer_?.IBU)!) )"
        }
    }
    
    let profileImageThumbnail: UIImageView = {
        let iv = UIImageView()
        iv.layer.cornerRadius = 25
        iv.layer.masksToBounds = true
        iv.translatesAutoresizingMaskIntoConstraints = false
        return iv
    }()
    
    override init(style: UITableViewCell.CellStyle, reuseIdentifier: String?) {
        super.init(style: .subtitle, reuseIdentifier: reuseIdentifier)
        self.selectionStyle = SelectionStyle.none
        contentView.isUserInteractionEnabled = false
        addSubview(profileImageThumbnail)
        backgroundColor = .color3
    }
    
    func setupConstraints() {
        profileImageThumbnail.leftAnchor.constraint(equalTo: leftAnchor, constant: 15).isActive = true
        profileImageThumbnail.centerYAnchor.constraint(equalTo: centerYAnchor).isActive = true
        profileImageThumbnail.heightAnchor.constraint(equalToConstant: 50).isActive = true
        profileImageThumbnail.widthAnchor.constraint(equalToConstant: 50).isActive = true
        
        textLabel?.frame = CGRect(x: 70, y: textLabel!.frame.origin.y - 2, width: textLabel!.frame.width, height: textLabel!.frame.height )
        
        detailTextLabel?.frame = CGRect(x: 70, y: detailTextLabel!.frame.origin.y + 2, width: detailTextLabel!.frame.width, height: detailTextLabel!.frame.height )
        
    }
        
    required init?(coder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
}

