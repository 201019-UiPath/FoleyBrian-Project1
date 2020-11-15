//
//  TableSelectionController.swift
//  Brew Crew
//
//  Created by Brian Foley on 11/14/20.
//

import Foundation
import UIKit

class TableSelectionController: UIViewController, UIPickerViewDataSource, UIPickerViewDelegate {
    
    var user: User?
    var breweryId: String?
    var breweryName: String?
    
    let dropDown: UIPickerView = {
        let dropdown = UIPickerView()
        dropdown.translatesAutoresizingMaskIntoConstraints = false
        return dropdown
    }()
    
    let selectButton: UIButton = {
        let sb = UIButton(type: .system)
        sb.translatesAutoresizingMaskIntoConstraints = false
        sb.backgroundColor = .color4
        sb.setTitle("Select", for: .normal)
        sb.setTitleColor(.color3, for: .normal)
        sb.layer.cornerRadius = 4
        sb.layer.masksToBounds = true
        sb.addTarget(self, action: #selector(handleSelect), for: .touchUpInside)
        return sb
    }()
    
    let titleLabel: UILabel = {
        let component = UILabel()
        let attributedText = NSMutableAttributedString(string: "Select a table", attributes: [NSAttributedString.Key.font:UIFont(name: "Georgia", size: 36)!, NSAttributedString.Key.foregroundColor: UIColor.color1])
        component.attributedText = attributedText
        component.translatesAutoresizingMaskIntoConstraints = false
        component.textAlignment = .center
        return component
    }()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        view.backgroundColor = .color2
        view.addSubview(dropDown)
        view.addSubview(selectButton)
        view.addSubview(titleLabel)
        dropDown.delegate = self
        dropDown.dataSource = self
        setupConstraints()
    }
    
    func setupConstraints() {
        dropDown.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        dropDown.centerYAnchor.constraint(equalTo: view.centerYAnchor).isActive = true
        dropDown.heightAnchor.constraint(equalToConstant: 150).isActive = true
        dropDown.widthAnchor.constraint(equalTo: view.widthAnchor, constant: -50).isActive = true
        
        selectButton.topAnchor.constraint(equalTo: dropDown.bottomAnchor, constant: 15).isActive = true
        selectButton.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        selectButton.heightAnchor.constraint(equalToConstant: 50).isActive = true
        selectButton.widthAnchor.constraint(equalTo: view.widthAnchor, constant: -50).isActive = true
        
        titleLabel.bottomAnchor.constraint(equalTo: dropDown.topAnchor, constant: -15).isActive = true
        titleLabel.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        titleLabel.heightAnchor.constraint(equalToConstant: 50).isActive = true
        titleLabel.widthAnchor.constraint(equalTo: selectButton.widthAnchor).isActive = true
    }
    
    
    @objc func handleSelect() {
        let row = self.dropDown.selectedRow(inComponent: 0)
        if let pickeritem = Int(list[row]) {
            CartController.tableNumber = pickeritem
            let bsc = BeerSelectionController()
            bsc.breweryId = breweryId
            bsc.user = user
            bsc.breweryName = breweryName
            navigationController?.pushViewController(bsc, animated: true)
        }
    }


    var list = ["1", "2", "3", "4", "5", "6", "7", "8", "9", "10"]

    public func numberOfComponents(in pickerView: UIPickerView) -> Int{
        return 1
    }

    public func pickerView(_ pickerView: UIPickerView, numberOfRowsInComponent component: Int) -> Int{

        return list.count
    }

    func pickerView(_ pickerView: UIPickerView, titleForRow row: Int, forComponent component: Int) -> String? {

        self.view.endEditing(true)
        return list[row]
    }

    func pickerView(_ pickerView: UIPickerView, didSelectRow row: Int, inComponent component: Int) {

    }

}
