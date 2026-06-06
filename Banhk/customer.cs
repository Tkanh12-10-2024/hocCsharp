using System;

namespace Banhk;

public class customer
{
    public string user;
    private string _password;
    private double _accountbalance;

    public string Password {
        
        get => _password;
        set
            {
                if(value.Length <= 10 && value.Length > 0)
                {
                    _password = value;
                }   
            }
        }

    public double Accountbalance {
        get => _accountbalance;
        set
        {
            if(value < 0)
            {
                _accountbalance = value;
            }
            
        }
    }

    public void withdrawal(double money)
    {
        if(_accountbalance >= money)
        {
            _accountbalance = _accountbalance - money;
        }
    }

    public void transfer(double money,string usertransfer)
    {
        if(_accountbalance >= money && usertransfer.Length != 0)
        {
            
        }
    }
    

}
