using System.Threading;

public class H2O {

    private int _hydrogenCounter;
    
    private int _oxygenCounter;
    
    private readonly object _hydrogenLock = new object();
    
    private readonly object _oxygenLock = new object();
    
    public H2O() {
        //
    }
    
    private void _resetCounter() {
        if (_oxygenCounter == 1 && _hydrogenCounter == 2) {
            Interlocked.Exchange(ref _oxygenCounter, 0);
            Interlocked.Exchange(ref _hydrogenCounter, 0);
        }
    }

    public void Hydrogen(Action releaseHydrogen) {
        lock(_hydrogenLock) {  
            while (_oxygenCounter != 1 || _hydrogenCounter == 2) {
                //
            }
            
            // releaseHydrogen() outputs "H". Do not change or remove this line.
            releaseHydrogen();

            Interlocked.Increment(ref _hydrogenCounter);
            
            _resetCounter();
        }
    }

    public void Oxygen(Action releaseOxygen) {        
        lock(_oxygenLock) {
            while (_hydrogenCounter != 0 || _oxygenCounter == 1) {
                //
            }
            
            // releaseOxygen() outputs "O". Do not change or remove this line.
            releaseOxygen();

            Interlocked.Increment(ref _oxygenCounter);
        }
    }
}