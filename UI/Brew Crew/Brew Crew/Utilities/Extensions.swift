//
//  Extensions.swift
//  Brew Crew
//
//  Created by Brian Foley on 11/9/20.
//

import UIKit

extension UIView {
    
    func anchor(top: NSLayoutYAxisAnchor?, left: NSLayoutXAxisAnchor?, bottom: NSLayoutYAxisAnchor?, right: NSLayoutXAxisAnchor?,  paddingTop: CGFloat, paddingLeft: CGFloat, paddingBottom: CGFloat, paddingRight: CGFloat, width: CGFloat, height: CGFloat) {
        
        translatesAutoresizingMaskIntoConstraints = false
        
        if let top = top {
            topAnchor.constraint(equalTo: top, constant: paddingTop).isActive = true
        }
        
        if let bottom = bottom {
            bottomAnchor.constraint(equalTo: bottom, constant: paddingBottom).isActive = true
        }

        if let left = left {
            leftAnchor.constraint(equalTo: left, constant: paddingLeft).isActive = true
        }
        
        if let right = right {
            rightAnchor.constraint(equalTo: right, constant: -paddingRight).isActive = true
        }
        if width != 0 {
            widthAnchor.constraint(equalToConstant: width).isActive = true
        }
           
        if height != 0 {
           heightAnchor.constraint(equalToConstant: height).isActive = true
        }
    }
}

extension UIColor {
    static func rgb(red: CGFloat, green: CGFloat, blue: CGFloat, alpha: CGFloat) -> UIColor {
        return UIColor(displayP3Red: red/255, green: green/255, blue: blue/255, alpha: alpha)
    }
    static var color1 = UIColor.rgb(red: 92,green:72,blue: 20,alpha: 36)
    static var color2 = UIColor.rgb(red: 225,green:195,blue: 117,alpha: 88)
    static var color3 = UIColor.rgb(red: 219,green:171,blue: 48,alpha: 86)
    static var color4 = UIColor.rgb(red: 92,green:83,blue: 60,alpha: 36)
    static var color5 = UIColor.rgb(red: 168,green:131,blue: 37,alpha: 66)
}
