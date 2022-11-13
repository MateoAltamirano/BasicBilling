import { Flex, TabPanels, TabPanel } from '@chakra-ui/react';
import PaymentHistory from './PaymentHistory';
import PendingBills from './PendingBills';

const Content = () => {
  return (
    <Flex h={'100%'} p={'1.5rem'} w={'100%'}>
      <Flex h={'100%'} w={'100%'}>
        <TabPanels display={'flex'}>
          <TabPanel
            p={'0'}
            w={'100%'}
            justifyContent={'center'}
            display={'flex'}
          >
            <PaymentHistory />
          </TabPanel>
          <TabPanel
            p={'0'}
            w={'100%'}
            justifyContent={'center'}
            display={'flex'}
          >
            <PendingBills />
          </TabPanel>
        </TabPanels>
      </Flex>
    </Flex>
  );
};

export default Content;
