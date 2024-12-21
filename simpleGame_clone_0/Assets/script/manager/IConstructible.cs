using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IConstructible
{
    bool CanConstruct(); 
    void Construct();    
    bool CanUpgrade(); 
    void Upgrade(); 
}
