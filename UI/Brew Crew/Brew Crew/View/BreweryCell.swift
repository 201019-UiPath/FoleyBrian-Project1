//
//  BreweryCell.swift
//  Brew Crew
//
//  Created by Brian Foley on 11/11/20.
//

import UIKit

class BreweryCell: UITableViewCell {
    
    override func layoutSubviews() {
        super.layoutSubviews()
        setupConstraints()
    }
    
    var brewery: Brewery? {
        didSet {
            textLabel?.text = brewery?.Name
            detailTextLabel?.text = "\(brewery?.Address ?? ""), \(brewery?.City ?? ""), \(brewery?.State ?? "")"
            //guard let profileImageUrl = user?.profileImageURL else { return }
//            APIService.shared.fetchImage(urlString: profileImageUrl) { (thumbnailImage) in
//                self.profileImageThumbnail.image = thumbnailImage
//            }
            
        }
    }
    
    let profileImageThumbnail: UIImageView = {
        let iv = UIImageView()
        iv.image = UIImage(named: "logo")
        iv.layer.cornerRadius = 25
        iv.contentMode = .scaleAspectFit
        iv.layer.masksToBounds = true
        iv.translatesAutoresizingMaskIntoConstraints = false
        return iv
    }()

    
    override init(style: UITableViewCell.CellStyle, reuseIdentifier: String?) {
        super.init(style: .subtitle, reuseIdentifier: reuseIdentifier)
        backgroundColor = .color3
        self.selectionStyle = SelectionStyle.none
        contentView.isUserInteractionEnabled = false
        addSubview(profileImageThumbnail)
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

