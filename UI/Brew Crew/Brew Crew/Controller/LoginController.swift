//
//  ViewController.swift
//  Brew Crew
//
//  Created by Brian Foley on 11/9/20.
//

import UIKit

class LoginController: UIViewController {

    let titleImage: UIImageView = {
       let component = UIImageView()
        component.image = UIImage(named: "cheers")
        component.backgroundColor = UIColor(white: 1, alpha: 0)
        component.translatesAutoresizingMaskIntoConstraints = false
        component.contentMode = .scaleAspectFill
        return component
    }()
    
    let stackView: UIStackView = {
       let component = UIStackView()
        component.distribution = .fillEqually
        component.axis = .vertical
        component.spacing = 10
       return component
    }()
    
    let emailTextField: UITextField = {
        let component = UITextField()
        component.placeholder = "Email"
        component.backgroundColor = UIColor(white: 0, alpha: 0.03)
        component.borderStyle = .roundedRect
        component.font = UIFont.systemFont(ofSize: 14)
        component.addTarget(self, action: #selector(handleTextChange), for: .editingChanged)
        return component
    }()
    
    let passwordTextField: UITextField = {
        let component = UITextField()
        component.placeholder = "Password"
        component.backgroundColor = UIColor(white: 0, alpha: 0.03)
        component.borderStyle = .roundedRect
        component.font = UIFont.systemFont(ofSize: 14)
        component.addTarget(self, action: #selector(handleTextChange), for: .editingChanged)
        component.isSecureTextEntry = true
        return component
    }()
    
    let loginButton: UIButton = {
        let component = UIButton(type: .system)
        component.setTitle("Login", for: .normal)
        component.addTarget(self, action: #selector(handleLogin), for: .touchUpInside)
        component.translatesAutoresizingMaskIntoConstraints = false
        component.isEnabled = false
        component.backgroundColor = .color3
        component.layer.cornerRadius = 4
        component.layer.masksToBounds = true
        component.titleLabel?.font = UIFont(name: "Georgia", size: 14)
        component.setTitleColor(.color2, for: .normal)
        return component
    }()
    
    let registerButton: UIButton = {
        let component = UIButton(type: .system)
        let attributedText = NSMutableAttributedString(string: "Need an Account? ", attributes: [NSAttributedString.Key.font:UIFont(name: "Georgia", size: 14)!, NSAttributedString.Key.foregroundColor: UIColor.lightGray])
        attributedText.append(NSAttributedString(string: "Register Here", attributes: [NSAttributedString.Key.foregroundColor: UIColor.color5, NSAttributedString.Key.font: UIFont(name: "Georgia", size: 14)!]))
        component.translatesAutoresizingMaskIntoConstraints = false
        component.setAttributedTitle(attributedText, for: .normal)
        component.addTarget(self, action: #selector(handleRegister), for: .touchUpInside)
        return component
    }()
    
    let noticeLabel: UILabel = {
       let label = UILabel()
        label.textColor = .red
        label.translatesAutoresizingMaskIntoConstraints = false
        return label
    }()
    
    let activityIndicatorView: UIActivityIndicatorView = {
        let aiv = UIActivityIndicatorView(style: .large)
        aiv.translatesAutoresizingMaskIntoConstraints = false
        aiv.backgroundColor = UIColor(white: 0, alpha: 0.5)
        aiv.isOpaque = true
        return aiv
    }()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        view.backgroundColor = .color2
        navigationController?.navigationBar.isHidden = true
        view.addSubview(titleImage)
        view.addSubview(stackView)
        stackView.addArrangedSubview(emailTextField)
        stackView.addArrangedSubview(passwordTextField)
        view.addSubview(loginButton)
        view.addSubview(registerButton)
        view.addSubview(noticeLabel)
        view.addSubview(activityIndicatorView)
        setupConstraints()
        addGestureRecognizers()
    }
    
    @objc func handleTextChange() {
        let isFormValid = !passwordTextField.text!.isEmpty && !emailTextField.text!.isEmpty
        if isFormValid {
            loginButton.setTitleColor(.color3, for: .normal)
            loginButton.isEnabled = true
            loginButton.backgroundColor = UIColor.color4
        } else {
            loginButton.setTitleColor(UIColor.color2, for: .normal)
            loginButton.isEnabled = false
            loginButton.backgroundColor = UIColor.color3
        }
    }
    
    func addGestureRecognizers() {
        view.addGestureRecognizer(UITapGestureRecognizer(target: self, action: #selector(dismissKeyboard)))
    }
    
    @objc func dismissKeyboard() {
        for textField in stackView.arrangedSubviews {
            textField.resignFirstResponder()
        }
    }
    
    var titleImageTopAnchor: NSLayoutConstraint?
    
    func setupConstraints() {
        titleImageTopAnchor = titleImage.topAnchor.constraint(equalTo: view.bottomAnchor, constant: 10)
        titleImageTopAnchor?.isActive = true
        titleImage.heightAnchor.constraint(equalToConstant: 200).isActive = true
        titleImage.widthAnchor.constraint(equalToConstant: 200).isActive = true
        titleImage.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        
        stackView.anchor(top: titleImage.bottomAnchor, left: nil, bottom: nil, right: nil, paddingTop: 15, paddingLeft: 0, paddingBottom: 0, paddingRight: 0, width: 350, height: 100)
        stackView.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        
        loginButton.anchor(top: stackView.bottomAnchor, left: stackView.leftAnchor, bottom: nil, right: stackView.rightAnchor, paddingTop: 15, paddingLeft: 0, paddingBottom: 0, paddingRight: 0, width: 0, height: 50)
        loginButton.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        
        registerButton.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        
        loginButton.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        
        noticeLabel.anchor(top: loginButton.bottomAnchor, left: nil, bottom: nil, right: nil, paddingTop: 15, paddingLeft: 0, paddingBottom: -12, paddingRight: 0, width: 350, height: 20)
        noticeLabel.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        
        registerButton.anchor(top: noticeLabel.bottomAnchor, left: nil, bottom: nil, right: nil, paddingTop: 15, paddingLeft: 0, paddingBottom: 0, paddingRight: 0, width: 0, height: 50)
        registerButton.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        
        activityIndicatorView.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        activityIndicatorView.centerYAnchor.constraint(equalTo: view.centerYAnchor).isActive = true
        activityIndicatorView.heightAnchor.constraint(equalTo: view.heightAnchor).isActive = true
        activityIndicatorView.widthAnchor.constraint(equalTo: view.widthAnchor).isActive = true
        view.layoutIfNeeded()
        
        titleImageTopAnchor?.isActive = false
        titleImageTopAnchor = titleImage.topAnchor.constraint(equalTo: view.safeAreaLayoutGuide.topAnchor, constant: 10)
        titleImageTopAnchor?.isActive = true
        
        UIView.animate(withDuration: 0.75, delay: 0, usingSpringWithDamping: 1, initialSpringVelocity: 1, options: .curveEaseIn, animations: {
            
            self.view.layoutIfNeeded()
        }, completion: nil)
    }
    
    @objc func handleLogin() {
        guard let email = emailTextField.text, let password = passwordTextField.text, !email.isEmpty, !password.isEmpty else {
            return
        }
        
        APIService.shared.validateSignIn(email: email, password: password) { (bool, user) in
            self.activityIndicatorView.stopAnimating()
            if bool {
                let brewerySelectionController = BrewerySelectionController()
                brewerySelectionController.user = user
                let navigationController = UINavigationController(rootViewController: brewerySelectionController)
                navigationController.modalPresentationStyle = .fullScreen
                self.present(navigationController, animated: true, completion: nil)
                print("Success")
            } else {
                print("Failed")
                self.noticeLabel.text = "Login Failed"
                
            }
        }
        self.activityIndicatorView.startAnimating()
    }
        
    lazy var registerController: RegisterController = {
        let controller = RegisterController()
        return controller
    }()
    
    @objc func handleRegister() {
        registerController.loginController = self
        modalPresentationStyle = .popover
        present(registerController, animated: true)
    }
}

