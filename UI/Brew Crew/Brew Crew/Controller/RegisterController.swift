//
//  RegisterController.swift
//  Brew Crew
//
//  Created by Brian Foley on 11/9/20.
//

import UIKit

class RegisterController: UIViewController {

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
        component.translatesAutoresizingMaskIntoConstraints = false
        //component.backgroundColor = .lightGray
       return component
    }()
    
    let FirstNameTextField: UITextField = {
        let component = UITextField()
        component.placeholder = "First Name"
        component.backgroundColor = UIColor(white: 0, alpha: 0.03)
        component.borderStyle = .roundedRect
        component.font = UIFont.systemFont(ofSize: 14)
        component.addTarget(self, action: #selector(handleTextChange), for: .editingChanged)
        return component
    }()
    
    let LastNameTextField: UITextField = {
        let component = UITextField()
        component.placeholder = "Last Name"
        component.backgroundColor = UIColor(white: 0, alpha: 0.03)
        component.borderStyle = .roundedRect
        component.font = UIFont.systemFont(ofSize: 14)
        component.addTarget(self, action: #selector(handleTextChange), for: .editingChanged)
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
    
    let passwordVerificationTextField: UITextField = {
        let component = UITextField()
        component.placeholder = "Verify Password"
        component.backgroundColor = UIColor(white: 0, alpha: 0.03)
        component.borderStyle = .roundedRect
        component.font = UIFont.systemFont(ofSize: 14)
        component.addTarget(self, action: #selector(handleTextChange), for: .editingChanged)
        component.isSecureTextEntry = true
        return component
    }()
    
    let registerButton: UIButton = {
        let component = UIButton(type: .system)
        component.setTitle("Register", for: .normal)
        component.addTarget(self, action: #selector(handleLogin), for: .touchUpInside)
        component.translatesAutoresizingMaskIntoConstraints = false
        component.backgroundColor = .color3
        component.layer.cornerRadius = 4
        component.layer.masksToBounds = true
        component.titleLabel?.font = UIFont(name: "Georgia", size: 14)
        component.setTitleColor(UIColor.color2, for: .normal)
        component.isEnabled = false
        return component
    }()
    
    let loginButton: UIButton = {
        let component = UIButton(type: .system)
        let attributedText = NSMutableAttributedString(string: "Already have an Account? ", attributes: [NSAttributedString.Key.font:UIFont(name: "Georgia", size: 14)!, NSAttributedString.Key.foregroundColor: UIColor.lightGray])
        attributedText.append(NSAttributedString(string: "Sign in Here", attributes: [NSAttributedString.Key.foregroundColor: UIColor.color4, NSAttributedString.Key.font: UIFont(name: "Georgia", size: 14)!]))
        component.setAttributedTitle(attributedText, for: .normal)
        component.addTarget(self, action: #selector(handleRegister), for: .touchUpInside)
        return component
    }()
    
    override func viewDidLoad() {
        super.viewDidLoad()
        view.backgroundColor = .color2
        navigationController?.navigationBar.isHidden = true
        view.addSubview(titleImage)
        view.addSubview(stackView)
        stackView.addArrangedSubview(FirstNameTextField)
        stackView.addArrangedSubview(LastNameTextField)
        stackView.addArrangedSubview(emailTextField)
        stackView.addArrangedSubview(passwordTextField)
        stackView.addArrangedSubview(passwordVerificationTextField)
        view.addSubview(loginButton)
        view.addSubview(registerButton)
        setupConstraints()
        addGestureRecognizers()
    }
    
    @objc func handleTextChange() {
        let isFormValid = !passwordTextField.text!.isEmpty && !emailTextField.text!.isEmpty && !LastNameTextField.text!.isEmpty && !FirstNameTextField.text!.isEmpty && !passwordVerificationTextField.text!.isEmpty
        if isFormValid {
            registerButton.setTitleColor(UIColor.color3, for: .normal)
            registerButton.isEnabled = true
            registerButton.backgroundColor = UIColor.color4
            
        } else {
            registerButton.setTitleColor(UIColor.color2, for: .normal)
            registerButton.isEnabled = false
            registerButton.backgroundColor = UIColor.color3
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
        titleImage.anchor(top: view.safeAreaLayoutGuide.topAnchor, left: nil, bottom: nil, right: nil, paddingTop: 10, paddingLeft: 0, paddingBottom: 0, paddingRight: 0, width: 120, height: 120)
        titleImage.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        
        stackView.anchor(top: titleImage.bottomAnchor, left: nil, bottom: nil, right: nil, paddingTop: 15, paddingLeft: 0, paddingBottom: 0, paddingRight: 0, width: 350, height: 250)
        stackView.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        
        registerButton.anchor(top: stackView.bottomAnchor, left: stackView.leftAnchor, bottom: nil, right: stackView.rightAnchor, paddingTop: 15, paddingLeft: 0, paddingBottom: 0, paddingRight: 0, width: 0, height: 50)
        registerButton.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
        
        loginButton.anchor(top: nil, left: nil, bottom: view.safeAreaLayoutGuide.bottomAnchor, right: nil, paddingTop: 0, paddingLeft: 0, paddingBottom: -12, paddingRight: 0, width: 350, height: 20)
        loginButton.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
    }
    
    var loginController: LoginController?
    
    @objc func handleLogin() {
        guard let email = emailTextField.text, let password = passwordTextField.text, let firstName = FirstNameTextField.text, let lastName = LastNameTextField.text, let passwordVerification = passwordVerificationTextField.text, !email.isEmpty, !password.isEmpty, !firstName.isEmpty, !lastName.isEmpty, !passwordVerification.isEmpty else {
            return
        }
        
        if !(passwordVerification.elementsEqual(password)) {
            print("Passwords do not match")
            return
        }
        
        APIService.shared.registerUser(firstName: firstName, lastName: lastName, email: email, password: password) { (bool,user) in
            if bool {
                let brewerySelectionController = BrewerySelectionController()
                brewerySelectionController.user = user
                let navController = UINavigationController(rootViewController: brewerySelectionController)
                navController.modalPresentationStyle = .fullScreen
                self.present(navController, animated: true, completion: nil)
            }
        }
    }
    
    @objc func handleRegister() {
        self.dismiss(animated: true, completion: nil)
    }
}
